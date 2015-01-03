using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float force = 50f;

	private bool is3DView = false;

	void ChangeView() {
		is3DView = !is3DView;
		if (is3DView)
			transform.rotation = new Quaternion(0,0,0,0);
		rigidbody.freezeRotation = is3DView;
	}

	void Move3D()
	{
		if (Input.GetKey(KeyCode.UpArrow)) 
			rigidbody.AddRelativeForce(Vector3.forward * force);
		
		if (Input.GetKey(KeyCode.DownArrow)) 
			rigidbody.AddRelativeForce(Vector3.back * force);

		if (Input.GetKey(KeyCode.LeftArrow)) 
			transform.Rotate(Vector3.down * 2);
		
		if (Input.GetKey(KeyCode.RightArrow)) 
			transform.Rotate(Vector3.up * 2);
	}

	void MoveTop()
	{		
		if (Input.GetKey(KeyCode.UpArrow)) 
			rigidbody.AddForce(Vector3.forward * force);
		
		if (Input.GetKey(KeyCode.DownArrow)) 
			rigidbody.AddForce(Vector3.back * force);

		if (Input.GetKey(KeyCode.LeftArrow)) 
			rigidbody.AddForce(Vector3.left * force);
		
		if (Input.GetKey(KeyCode.RightArrow)) 
			rigidbody.AddForce(Vector3.right * force);
	}

	void FixedUpdate () {
		if (is3DView)
			Move3D();
		else
			MoveTop();
	}
}
