using UnityEngine;
using System.Collections;

public class DeviceTilt : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

		rigidbody.AddForce(Input.acceleration * 5);

	}
}
