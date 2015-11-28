using UnityEngine;
using System.Collections;

public class AddCoins : MonoBehaviour {

	public GameObject coin;
	
	void Update () {
		if (Time.timeScale > 0 && Random.value > 0.99f)
			AddCoin (Random.Range (-6f, 10f), Random.Range (0f, -2f));
	}

	void AddCoin (float x, float y ) {
		Vector3 position = new Vector3 (x, y, 0);
		Instantiate (coin, position, Quaternion.identity);
	}
}
