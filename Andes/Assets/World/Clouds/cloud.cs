using UnityEngine;
using System.Collections;

public class cloud : MonoBehaviour {

	public float speed = 0.01f;
	public float oscil = 1f;

	private float y = 0;
	private float max = 40f;

	void Start () {
		y = transform.position.y;
		if (speed == 0.01f)
			speed = Random.Range(0.003f,0.01f);
		if (oscil == 1f)
			oscil = Random.Range(1f,3f);
	}

	void Update () {
		float x = transform.position.x + speed;
		if (x > max) x = -max;
		if (x < -max) x = max;
		float inc = Mathf.Sin (x) * oscil;
		transform.position = new Vector3 (x, y + inc, transform.position.z); 
	}
}
