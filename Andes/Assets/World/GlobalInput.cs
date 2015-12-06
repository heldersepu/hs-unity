using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalInput : MonoBehaviour {

	public GameObject helpPanel;
	public GameObject mainCamera;
	public GameObject orc;

	private Camera cam;
	void Start () {
		cam = mainCamera.GetComponent<Camera> ();
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
			cam.orthographicSize = (cam.orthographicSize ==8) ? 10 : 8;
		}
		if (cam.orthographicSize == 8) {
			var pos = mainCamera.transform.position;
			pos.x = orc.transform.position.x;
			mainCamera.transform.position = pos;
		} else {
			mainCamera.transform.position = new Vector3(0,0,-100);
		}

	}

	void ChangeState(bool show){
		Time.timeScale = show ? 0: 1;
		helpPanel.SetActive(show);
	}
}
