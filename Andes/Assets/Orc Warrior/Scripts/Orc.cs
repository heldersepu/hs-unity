﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Orc : MonoBehaviour {

	public float speed = 10f;
	public Text orc;
	public Text coins;

	private Animator anim;
	private Rigidbody2D rbody;
	private int lastJump = 0;
	private int lastAttack = 0;
	private GameObject head;
	private SpriteRenderer weapon;

	void Start () {
		anim = GetComponent<Animator>();
		rbody = GetComponent<Rigidbody2D> ();
		head = GameObject.Find("orc_head");
		var orc_weapon = GameObject.Find("orc_weapon");
		weapon = orc_weapon.GetComponent<SpriteRenderer> ();
	}

	void Update () {
		int shift = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
		float horiz = Input.GetAxis ("Horizontal");
		float verti = Input.GetAxis ("Vertical");
		if (horiz != 0) {
			if (Mathf.Abs (rbody.velocity.y) < 0.8)
				rbody.AddForce (Vector3.right * horiz * speed * shift);
			if ((horiz < 0 && transform.localScale.x > 0) || (horiz > 0 && transform.localScale.x < 0) )  
				flip (transform);
		}
		anim.SetFloat ("speed", Mathf.Abs(rbody.velocity.x));
		if (verti > 0 && (Time.frameCount - lastJump > 100)) {
			rbody.AddForce (Vector3.up * 400);
			lastJump = Time.frameCount;
		}
		if (IsWeaponVisible() && Input.GetButton("Fire1") && (Time.frameCount - lastAttack > 100)) {
			anim.SetFloat ("speed", 0);
			anim.SetTrigger ("attack");
			lastAttack = Time.frameCount;
		} else {
			anim.SetFloat ("speed", Mathf.Abs (rbody.velocity.x));
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log (col.gameObject.name);
		if (col.gameObject.name.Equals ("goblin_arrow")) {
			flipHead ();
			Destroy (col.gameObject);
			Invoke ("flipHead", 0.4f);
			orc.text = (int.Parse(orc.text)-5).ToString();
		} else if (col.gameObject.name.StartsWith ("coin")) {
			Destroy (col.gameObject);
			coins.text = (int.Parse(coins.text)+1).ToString();
		} else if (col.gameObject.name.StartsWith ("orc_weapon")) {
			Destroy (col.gameObject);
			weapon.sortingOrder = 0;			
		}
	}

	void flipHead() {
		flip (head.transform);
	}

	void flip(Transform t) {
		var s = t.localScale;
		s.x *= -1;
		t.localScale = s;
	}

	bool IsWeaponVisible() { 
		return (weapon.sortingOrder == 0);
	}

}
