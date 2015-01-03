using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;  

public class Ship : MonoBehaviour {
	public float MaxSpeed = 5f;
	public float RotationSpeed = 2.5f;
	public int MaxMissiles = 10;
	public int MaxMines = 5;
	public GameObject Missile;
	public GameObject Mine;
	public Scrollbar hSlider;
	public Scrollbar vSlider;

	private List<GameObject> dMissiles = new List<GameObject>();
	private List<GameObject> dMines = new List<GameObject>();
	private float spd = 0.05f;
	private Animator anim;
	private float turn = 0.5f;
	private float thrust = 0;
	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		dMissiles.Remove(null);
	}

	void FixedUpdate () {
		int shift = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
		bool acce = (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) || thrust > 0);
		anim.SetBool ("Fast", acce);

		if (acce)
			rigidbody2D.AddRelativeForce(Vector3.right * MaxSpeed * shift);

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || turn > 0.6)
			transform.Rotate (0, 0, RotationSpeed * shift);

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || turn < 0.4)
			transform.Rotate (0, 0, -RotationSpeed * shift);
		
		if (Input.GetKey(KeyCode.Space)) shoot ();

		if (Input.GetKeyDown(KeyCode.M)) mine ();
	}

	void doturn()
	{
		Debug.Log(hSlider.value);
		turn = hSlider.value;
	}

	void dothrust()
	{
		thrust = vSlider.value;
	}

	void shoot() {
		if (dMissiles.Count < MaxMissiles) {	
			GameObject misil = (GameObject)Instantiate(Missile, transform.position , Quaternion.identity);
			misil.transform.rotation = transform.rotation;
			float angle = transform.rotation.eulerAngles.z * Mathf.PI / 180;
			float x = Mathf.Cos(angle)*10;
			x += x * spd * 10;
			float y = Mathf.Sin(angle)*10;
			y += y * spd * 10;
			misil.transform.rigidbody2D.velocity = new Vector3 (x, y, 0);
			dMissiles.Add(misil);
		}
	}

	void mine() {
		if (dMines.Count < MaxMines) {
			GameObject mine = null;
			for (int i = 0; i < 10; i++) {
				transform.Translate (0.001f, 0, 0);
				transform.Rotate (0, 0, 0.001f);
				mine = (GameObject)Instantiate (Mine, transform.position, Quaternion.identity);
				mine.transform.rigidbody2D.isKinematic = false;
			}
			dMines.Add(mine);
		}
	}


}
