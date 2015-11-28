using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public float delay = 3;
	private bool shrink = false;
	private float fade = 0.95f;

	void Start () {
		Invoke ("doShrink", delay);
	}

	void Update () {
		if (shrink) {
			var scale = this.transform.localScale;
			scale = new Vector3(scale.x * fade, scale.y * fade, scale.z * fade);
			this.transform.localScale = scale;
			if (scale.x < 0.0001f) Destroy (this.gameObject);
		}
	}

	void doShrink () {
		shrink = true;
	}
}
