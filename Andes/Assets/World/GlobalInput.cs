using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalInput : MonoBehaviour {

	public GameObject helpPanel;

	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			if (Time.timeScale == 0) {
				ChangeState(false);
			} else {
				ChangeState(true);
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ChangeState(false);
		}
	}

	void ChangeState(bool show){
		Time.timeScale = show ? 0: 1;
		helpPanel.SetActive(show);
	}
}
