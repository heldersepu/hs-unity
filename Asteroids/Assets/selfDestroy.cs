using UnityEngine;
using System.Collections;

public class selfDestroy : MonoBehaviour {
	public float timer = 1;
	void Start () {
		Destroy(gameObject, timer);
	}
}
