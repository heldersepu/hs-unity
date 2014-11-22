using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {
	void FixedUpdate () {
		transform.Rotate (0, 0.1f, 0);
	}
}
