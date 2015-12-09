using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

	public GameObject GreenParticles;
	private float fade = 0.9f;


	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log (col.gameObject.name);
		if (col.gameObject.name.StartsWith ("block")) {
			var scale = col.gameObject.transform.localScale;
			scale = new Vector3(scale.x * fade, scale.y * fade, scale.z * fade);
			col.gameObject.transform.localScale = scale;
			if (scale.x < 0.2) {
				Destroy (col.gameObject);
			} else {
				Instantiate (GreenParticles, col.gameObject.transform.position, Quaternion.identity);
				var rb = col.gameObject.GetComponent<Rigidbody2D> ();
				rb.constraints = RigidbodyConstraints2D.None; 
			}
		}
	}
}
