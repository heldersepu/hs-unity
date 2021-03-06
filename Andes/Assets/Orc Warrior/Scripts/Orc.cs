﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class Orc : MonoBehaviour {

	public float speed = 100f;
	public float jump = 4000f;
	public int coinCount = 0;
	public float energy = 100;
	public Text orc;
	public Text coins;

	private Animator anim;
	private Rigidbody2D rbody;
	private int lastJump = -100;
	private int lastAttack = -100;
	private GameObject head;
	private GameObject weapon;

	private AudioSource aSource;
	private List<AudioClip> grunts;
	public AudioClip grunt1;
	public AudioClip grunt2;
	public AudioClip grunt3;
	public AudioClip ouch;
	public AudioClip coin;

	void Start () {
		grunts = new List<AudioClip> { grunt1, grunt2, grunt3 };
		aSource = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		rbody = GetComponent<Rigidbody2D> ();
		head = GameObject.Find("orc_head");
		weapon = GameObject.Find("orc_weapon");
		weapon.SetActive(false);
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
		if (verti > 0 && okToJump()) {
			rbody.AddForce (Vector3.up * jump);
			lastJump = Time.frameCount;
			Analytics.CustomEvent ("jump", null);
		}
		if (weapon.activeSelf && (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space)) && okToAttack()) {
			anim.SetFloat ("speed", 0);
			anim.SetTrigger ("attack");
			lastAttack = Time.frameCount;
			Analytics.CustomEvent ("attack", null);
		} else {
			anim.SetFloat ("speed", Mathf.Abs (rbody.velocity.x));
		}
		coins.text = coinCount.ToString();
		orc.text = ((int)energy).ToString();
	}

	void OnTriggerEnter2D (Collider2D col) {		
		if (col.gameObject.name.Equals ("goblin_arrow")) {
			aSource.PlayOneShot (grunts[Random.Range (0, 2)]);
			flipHead ();
			Destroy (col.gameObject);
			Invoke ("flipHead", 0.4f);
			energy -= 5;
		} else if (col.gameObject.name.StartsWith ("coin")) {
			aSource.PlayOneShot (coin);
			Destroy (col.gameObject);
			coinCount++;
		} else if (col.gameObject.name.StartsWith ("orc_weapon")) {
			Destroy (col.gameObject);
			weapon.SetActive(true);
		} else if (col.gameObject.name.StartsWith ("GreenParticles")) {
			energy += 0.1f;
		} else {
			Debug.Log (col.gameObject.name);
		}
	}

	void flipHead() {
		flip(head.transform);
		var sr = head.GetComponent<SpriteRenderer>(); 
		sr.color = (sr.color == Color.white) ? Color.yellow : Color.white;
	}

	void flip(Transform t) {
		var s = t.localScale;
		s.x *= -1;
		t.localScale = s;
	}

	public bool okToJump() {
		return (Time.frameCount - lastJump > 60);
	}

	public bool okToAttack() {
		return (Time.frameCount - lastAttack > 60);
	}

}
