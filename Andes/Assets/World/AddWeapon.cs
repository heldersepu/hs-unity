using UnityEngine;
using System.Collections;

public class AddWeapon : MonoBehaviour {

	public GameObject weapon;
	private bool addWeapon = true;
	
	void Start () {
		weapon.GetComponent<Animator>().SetTrigger("idle");
	}

	void Update () {
		if (Time.timeScale > 0 && addWeapon && Time.frameCount > 500) {
			addWeapon = false;
			AddWeaponAt (15, -1);
		}
	}

	void AddWeaponAt (float x, float y ) {
		Vector3 position = new Vector3 (x, y, 0);
		Instantiate (weapon, position, Quaternion.identity);
	}
}
