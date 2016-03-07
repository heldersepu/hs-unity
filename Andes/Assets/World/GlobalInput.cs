using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Analytics;

public class GlobalInput : MonoBehaviour {

	public GameObject helpPanel;
	public GameObject mainCamera;
	public GameObject background;
	public Orc orc;

	private Camera cam;
	private float size;
	private Vector3 camPos = new Vector3 (0, 0, -100);
	void Start () {
		cam = mainCamera.GetComponent<Camera> ();
		size = cam.orthographicSize;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.F1) || Input.GetKeyDown (KeyCode.F2)) {			
			ChangeState(Time.timeScale != 0);
		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			ChangeState (false);
		} else if (Input.GetKeyDown (KeyCode.V)) {
			Analytics.CustomEvent ("ChangeView", null);
			size = (size == 8) ? 10 : 8;
			if (size == 10) 
				camPos = new Vector3 (0, 0, -100);
		}
		if (size == 8) {
			camPos.x = orc.transform.position.x;
			if (orc.okToJump())
				camPos.y = orc.transform.position.y+5;
			float d =  (Mathf.Abs (camPos.x - orc.transform.position.x) > 2) ? 0.3f: 0.5f; 				
			camPos = Vector3.MoveTowards (mainCamera.transform.position, camPos, d);
		}
		mainCamera.transform.position = camPos;
		background.transform.position = new Vector3 (camPos.x, camPos.y, 70);
		cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, size, 0.1f);
	}

	void ChangeState(bool show){
		Time.timeScale = show ? 0: 1;
		helpPanel.SetActive(show);
	}
}
