using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public float delay = 3;

	void Start () {
		Destroy (this.gameObject, delay);
	}
}
