using UnityEngine;
using System.Collections;

public class asteroid : MonoBehaviour {	
	public GameObject explosion1;
	public GameObject explosion2;
	
	private float vR, vX, vY = 0.001f;
	private Animator anim;

	void Start () {
		Quaternion rot = Random.rotation;
		transform.rotation = new Quaternion (rot.x, rot.y, 0, 0);
		vR = rot.z; vX = rot.x/10; vY = rot.y/10; 
		anim = GetComponent<Animator>();
		anim.SetInteger ("aster", Random.Range (0, 3));
	}
	

	void Update () {
		transform.position = new Vector3 (transform.position.x + vX, transform.position.y + vY, 0);
		transform.Rotate (0, 0, vR);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "abc")
			Instantiate (explosion1, transform.position, Quaternion.identity);
		else
			Instantiate (explosion2, transform.position, Quaternion.identity);
		Destroy(transform.gameObject);
	}
}
