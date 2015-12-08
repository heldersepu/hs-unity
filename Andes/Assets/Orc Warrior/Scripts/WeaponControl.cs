using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

	private float fade = 0.95f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log (col.gameObject.name);
		if (col.gameObject.name.StartsWith ("block")) {
			var scale = col.gameObject.transform.localScale;
			scale = new Vector3(scale.x * fade, scale.y * fade, scale.z * fade);
			col.gameObject.transform.localScale = scale;
			if (scale.x < 0.2) Destroy(col.gameObject);
		}
	}
}
