using UnityEngine;
using System.Collections;

public class Add_Weapon : MonoBehaviour {

	public GameObject weapon;
	private bool addWeapon = true;
	
	void Start () {
		var anim = weapon.GetComponent<Animator> ();
		anim.SetTrigger("idle");
	}

	void Update () {
		if (Time.timeScale > 0 && addWeapon && Time.frameCount > 500) {
			addWeapon = false;
			AddWeapon (15, -1);
		}
	}

	void AddWeapon (float x, float y ) {
		Vector3 position = new Vector3 (x, y, 0);
		Instantiate (weapon, position, Quaternion.identity);
	}
}
