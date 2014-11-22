using UnityEngine;
using System.Collections;

public class reset : MonoBehaviour {
	private GameObject[] players;
	private Vector3[] vectors;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Quad");
		vectors = new Vector3[players.Length];
		for (int i = 0; i < players.Length; i++)
		{
			vectors[i] = players[i].transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) 
		{
			if (players.Length == 0) 
			{
				Debug.LogError ("No Player");
			} else {
				for (int i = 0; i < vectors.Length; i++)
				{
					players[i].transform.position = vectors[i];
				}
			}
		}
	}
}
