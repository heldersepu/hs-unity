using UnityEngine;
using System.Collections;

public class misile : MonoBehaviour {

	public float Speed = 0.3f;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Speed, 0, 0);
	}
}
