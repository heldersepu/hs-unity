using UnityEngine;
using System.Collections;

public class Orc : MonoBehaviour {

	public float speed = 10f;
	private Animator anim;
	private Rigidbody2D rbody;
	private int lastJump = 0;
	private GameObject head;

	void Start () {
		anim = GetComponent<Animator>();
		rbody = GetComponent<Rigidbody2D> ();
		head = GameObject.Find("orc_head");
	}
	
	// Update is called once per frame
	void Update () {
		int shift = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
		float horiz = Input.GetAxis ("Horizontal");
		if (horiz != 0) {
			if (Mathf.Abs (rbody.velocity.y) < 0.8)
				rbody.AddForce (Vector3.right * horiz * speed * shift);
			if ((horiz < 0 && transform.localScale.x > 0) || (horiz > 0 && transform.localScale.x < 0) )  
				flip (transform);
		}
		anim.SetFloat ("speed", Mathf.Abs(rbody.velocity.x));
		if (Input.GetKeyUp (KeyCode.Space) && (Time.frameCount - lastJump > 100)) {
			rbody.AddForce (Vector3.up * 400);
			lastJump = Time.frameCount;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log (col.gameObject.name);
		if (col.gameObject.name.StartsWith ("arrow")) {
			Destroy (col.gameObject);
			flipHead();
			Invoke("flipHead",0.4f);
		}
	}

	void flipHead() {
		flip (head.transform);
	}

	void flip(Transform t) {
		var s = t.localScale;
		s.x *= -1;
		t.localScale = s;
	}

}
