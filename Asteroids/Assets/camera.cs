using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class camera : MonoBehaviour {
	public int MaxAsteroids = 8;
	public GameObject asteroid;

	private List<GameObject> dAsteroids = new List<GameObject>();

	void FixedUpdate () {
		if (Input.GetKey(KeyCode.Escape))
		    Application.Quit();
	}

	void createAster() {
		dAsteroids.Remove(null);
		if (dAsteroids.Count < MaxAsteroids) {
			Vector3 pos = new Vector3(dAsteroids.Count, 0 , 0);
			GameObject aster = (GameObject)Instantiate(asteroid, pos, Quaternion.identity);
			dAsteroids.Add(aster);   
		}
	}

	private float timer = 0;
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 2) {
			timer = 0;
			createAster();
		}
	}
}

