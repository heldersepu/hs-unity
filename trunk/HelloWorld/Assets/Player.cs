using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 0.3f;

	// Update is called once per frame
	void Update () {

		if ((speed < 3) && (Input.GetKey (KeyCode.W)))
			speed += 0.1f;
		if ((speed > -3) && (Input.GetKey (KeyCode.S)))
			speed -= 0.1f;
		Debug.Log (speed);
		transform.Rotate (0, 0, speed);
	}
}
