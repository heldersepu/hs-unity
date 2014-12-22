using UnityEngine;
using System.Collections;

public class asteroid : MonoBehaviour {	
	public GameObject explosion1;
	public GameObject explosion2;
	
	private float vR, vX, vY = 0.001f;
	private Animator anim;

	void Start () {
		Quaternion rot = Random.rotation;
		vR = rot.z; vX = rot.x/10; vY = rot.y/10; 
		anim = GetComponent<Animator>();
		anim.SetInteger ("aster", Random.Range (0, 3));
	}

	void Update () {
		transform.Translate(new Vector3 (vX, vY, 0));
		transform.Rotate (0, 0, vR);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "ship") {
			Instantiate (explosion1, transform.position, Quaternion.identity);
		} else {
			Instantiate (explosion2, transform.position, Quaternion.identity);
			Destroy(col.gameObject);
		}
		Destroy(transform.gameObject);
	}
}
