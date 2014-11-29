using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float forwardSpeed = 0.03f;
	public float rotationSpeed = 0.1f;
	public float jumpPower = 2.5f;

	private int lastJump = 0;

	void Update () {
		if (transform.position.y < -5) {
			transform.position = new Vector3 (0, 5, -20);
			transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
		}
	}

	void FixedUpdate () {
		float spd = forwardSpeed;
		float srt = rotationSpeed;
		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			spd *= 2;
			srt *= 2;
		}

		if(Input.GetKey(KeyCode.A))
			transform.Rotate (0, -srt, 0);
		if(Input.GetKey(KeyCode.D))
			transform.Rotate (0, srt, 0);

		if(Input.GetKey(KeyCode.W))
			transform.Translate (0, 0, spd);
		if(Input.GetKey(KeyCode.S))
			transform.Translate (0, 0, -spd);
		if(Input.GetKey(KeyCode.E))
			transform.Translate (spd, 0, 0);
		if(Input.GetKey(KeyCode.Q))
			transform.Translate (-spd, 0, 0);

		if(Input.GetKeyUp(KeyCode.Space) && (Time.frameCount - lastJump > 50))
		{
			rigidbody.AddForce(new Vector3 (0, 5, 0) * jumpPower, ForceMode.Impulse);
			lastJump = Time.frameCount;
		}

	}
}
