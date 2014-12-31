using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {
	public float forwardSpeed = 0.12f;
	public float rotationSpeed = 2.5f;
	public int MaxMissiles = 10;
	public int MaxMines = 5;
	public GameObject Missile;
	public GameObject Mine;

	private List<GameObject> dMissiles = new List<GameObject>();
	private List<GameObject> dMines = new List<GameObject>();
	private float spd = 0.05f;
	private Animator anim;
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		dMissiles.Remove(null);
	}

	void FixedUpdate () {

		int shift = 1;
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) 
			shift = 2;

		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			transform.Rotate (0, 0, rotationSpeed * shift);
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			transform.Rotate (0, 0, -rotationSpeed * shift);

		bool fastAnim = false;
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow))
		{
			transform.rigidbody2D.constantForce  = forwardSpeed * shift;
			fastAnim = true;
		}
		anim.SetBool ("Fast", fastAnim);

		if(Input.GetKey(KeyCode.Space))
			shoot ();

		if(Input.GetKeyDown(KeyCode.M)) 
			mine ();
	}

	void shoot() {
		if (dMissiles.Count < MaxMissiles) {	
			GameObject misil = (GameObject)Instantiate(Missile, transform.position , Quaternion.identity);
			misil.transform.rotation = transform.rotation;
			float angle = transform.rotation.eulerAngles.z * Mathf.PI / 180;
			float x = Mathf.Cos(angle)*10;
			x += x * spd * 10;
			float y = Mathf.Sin(angle)*10;
			y += y * spd * 10;
			misil.transform.rigidbody2D.velocity = new Vector3 (x, y, 0);
			dMissiles.Add(misil);
		}
	}

	void mine() {
		if (dMines.Count < MaxMines) {
			GameObject mine = null;
			for (int i = 0; i < 10; i++) {
				transform.Translate (0.001f, 0, 0);
				transform.Rotate (0, 0, 0.001f);
				mine = (GameObject)Instantiate (Mine, transform.position, Quaternion.identity);
				mine.transform.rigidbody2D.isKinematic = false;
			}
			dMines.Add(mine);
		}
	}


}
