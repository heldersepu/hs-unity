using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float force = 50f;

	private bool is3DView = false;
	void Update () {

	}

	void ChangeView() {
		is3DView = !is3DView;
	}

	void FixedUpdate () {
		if (Input.GetKey(KeyCode.UpArrow)) {
			rigidbody.AddForce(Vector3.forward * force);
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			rigidbody.AddForce(Vector3.back * force);
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			rigidbody.AddForce(Vector3.left * force);
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			rigidbody.AddForce(Vector3.right * force);
		}
	}
}
