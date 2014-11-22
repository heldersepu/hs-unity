using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col)
	{
		GameObject obj = GameObject.Find("replayText");
		obj.transform.Translate (0, 0, -2);
	}
}
