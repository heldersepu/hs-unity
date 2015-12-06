using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalInput : MonoBehaviour {

	public GameObject helpPanel;
	public GameObject mainCamera;
	public GameObject orc;

	private Camera cam;
	private float size;
	void Start () {
		cam = mainCamera.GetComponent<Camera> ();
		size = cam.orthographicSize;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			if (Time.timeScale == 0) {
				ChangeState(false);
			} else {
				ChangeState(true);
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ChangeState (false);
		} else if (Input.GetKeyDown (KeyCode.V)) {
			size = (size == 8) ? 10 : 8;
		}
		if (size == 8) {
			var pos = mainCamera.transform.position;
			pos.x = Mathf.Lerp (pos.x, orc.transform.position.x, Time.time/60);
			mainCamera.transform.position = pos;
		} else {
			var x = Mathf.Lerp (mainCamera.transform.position.x, 0, Time.time/60);
			mainCamera.transform.position = new Vector3(x, 0, -100);
		}
		cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, size, Time.time/60);
	}

	void ChangeState(bool show){
		Time.timeScale = show ? 0: 1;
		helpPanel.SetActive(show);
	}
}
