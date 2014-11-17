using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Transform _playerTransf;
	// Use this for initialization
	void Start () {
		var player = this.GetComponent<Player>();
		_playerTransf = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		_playerTransf.Rotate (0, 0, 2);
	}
}
