using UnityEngine;
using System.Collections;

public class Goblin : MonoBehaviour {

	public GameObject arrow;

	private Animator anim;
	private System.DateTime time;

	void Start () {
		anim = GetComponent<Animator>();
		time = System.DateTime.Now;
	}

	void FixedUpdate () {

		if ((time.AddSeconds(2) < System.DateTime.Now) && (Random.Range (0, 100) < 7)) { 
			anim.SetBool ("attack", true);
			GameObject a = (GameObject)Instantiate(arrow, transform.position , Quaternion.identity);
			time = System.DateTime.Now;
		}
	}
}
