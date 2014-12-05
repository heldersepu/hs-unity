using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class camera : MonoBehaviour {
	public int max_asteroids = 8;
	public GameObject asteroid;

	private List<GameObject> dAsteroids = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dAsteroids.Count < max_asteroids) {
			Vector3 pos = new Vector3(dAsteroids.Count, 0 , 0);
			GameObject aster = (GameObject)Instantiate(asteroid, pos, Quaternion.identity);
			dAsteroids.Add(aster);   
		}

	}
}
