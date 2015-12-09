using UnityEngine;
using System.Collections;

public class ParticlesController : MonoBehaviour {

	void Start () {
		Destroy (this.gameObject, 5);
	}
}
