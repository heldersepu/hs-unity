using UnityEngine;
using System.Collections;

public class missile : MonoBehaviour {

	public float Speed = 0.3f;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Speed);
		//transform.Translate (Speed, 0, 0);
	}
}
