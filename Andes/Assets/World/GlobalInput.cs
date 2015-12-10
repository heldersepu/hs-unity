using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalInput : MonoBehaviour {

	public GameObject helpPanel;
	public GameObject mainCamera;
	public GameObject orc;

	private Camera cam;
	private float size;
	private Vector3 camPos = new Vector3 (0, 0, -100);
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
			if (size == 10) 
				camPos = new Vector3 (0, 0, -100);
		}
		if (size == 8) {
			if (Mathf.Abs (camPos.x - orc.transform.position.x) < 2)
				camPos.x = orc.transform.position.x;
			else {
				camPos.x = orc.transform.position.x;
				camPos = Vector3.MoveTowards (mainCamera.transform.position, camPos, 0.3f);
			}
		}
		mainCamera.transform.position = camPos;
		cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, size, 0.1f);
	}

	void ChangeState(bool show){
		Time.timeScale = show ? 0: 1;
		helpPanel.SetActive(show);
	}
}
