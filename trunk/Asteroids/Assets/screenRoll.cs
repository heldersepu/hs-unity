using UnityEngine;
using System.Collections;

public class screenRoll : MonoBehaviour {
	
	private float w, h;
	void Start () {
		//topX
		float ratio = (Camera.main.orthographicSize * 2) / Screen.height;
		w = Screen.width * ratio;
		h = Screen.height * ratio;
	}

	void Update () {
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

		if (pos.x < 0.0) // left of the camera's view
		{
			Debug.Log (transform.position);
			Debug.Log (w);
			transform.position = new Vector3 (transform.position.x + w, transform.position.y, transform.position.z); 

		}
		if (1.0 < pos.x) // right of the camera's view
			transform.position = new Vector3 (transform.position.x - w, transform.position.y, transform.position.z);

		if (pos.y < 0.0) // below the camera's view
			transform.position = new Vector3 (transform.position.x, transform.position.y + h, transform.position.z);
		if (1.0 < pos.y) // above the camera's view
			transform.position = new Vector3 (transform.position.x, transform.position.y - h, transform.position.z);
	}
}
