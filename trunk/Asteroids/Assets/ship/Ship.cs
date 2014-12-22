using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {
	public float forwardSpeed = 0.12f;
	public float rotationSpeed = 2.5f;
	public int MaxMisiles = 10;
	public GameObject misile;

	private List<GameObject> dMisiles = new List<GameObject>();
	private float spd = 0;
	private Animator anim;
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		dMisiles.Remove(null);
	}

	void FixedUpdate () {

		int shift = 1;
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) 
			shift = 2;

		if(Input.GetKey(KeyCode.Space))
		{
			if (dMisiles.Count < MaxMisiles) {
				GameObject misil = (GameObject)Instantiate(misile, transform.position , Quaternion.identity);
				misil.transform.rotation = transform.rotation;
				dMisiles.Add(misil);   
			}
		}


		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate (0, 0, rotationSpeed * shift);
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			transform.Rotate (0, 0, -rotationSpeed * shift);


		bool fastAnim = false;
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow))
		{
			spd = forwardSpeed * shift;
			fastAnim = true;
		}
		anim.SetBool ("Fast", fastAnim);

		transform.Translate (spd, 0, 0);
		spd *= 0.975f;
	}
	
}
