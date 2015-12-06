using UnityEngine;
using System.Collections;

public class CoinControl : MonoBehaviour {

	public float delay = 3;
	private bool shrink = false;
	private float fade = 0.95f;
	private Rigidbody2D rb; 

	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody2D>();
		Invoke ("doShrink", delay);
		Destroy (this.gameObject, delay * 5);
	}

	void Update () {
		if (shrink && rb.velocity.y == 0)
		{
			var scale = this.transform.localScale;
			scale = new Vector3(scale.x * fade, scale.y * fade, scale.z * fade);
			transform.localScale = scale;
			if (scale.x < 0.1f) Destroy (this.gameObject);
		}
		if (rb.velocity.y != 0) {
			rb.gravityScale = 1;

		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		rb.gravityScale = 1;
	}

	void doShrink () {
		shrink = true;
	}
}
