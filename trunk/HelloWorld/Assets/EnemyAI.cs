using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private bool moveIncoming = true;
	public float speed = 1/160;
	private Transform _playerTransf;
	private Transform _enemyTransf;
	private Vector3 initPos;

	// Use this for initialization
	void Start () {
		GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
		if (player.Length == 0) 
		{
			Debug.LogError ("No Player");
		} else {
			_playerTransf = player[0].transform;
		}
		var enemy = this.GetComponent<EnemyAI>();
		_enemyTransf = enemy.transform;
		initPos = _enemyTransf.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var moveAmount = speed * Time.deltaTime;
		if (moveIncoming)
			_enemyTransf.position = Vector3.MoveTowards (_enemyTransf.position, _playerTransf.position, moveAmount);
		else
			_enemyTransf.position = Vector3.MoveTowards (_enemyTransf.position, initPos, moveAmount);


		if (_enemyTransf.position.x == _playerTransf.position.x) 
			moveIncoming = false;
		else if (_enemyTransf.position.z == initPos.z) 
			moveIncoming = true;
		
	}
}
