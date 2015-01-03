using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public float speed = 0.25f;
	public GameObject ball;
	
	private bool followBall = false;
	void Start () {
	}
	
	void Update () {
		if (followBall) 
		{
			transform.position = ball.transform.position;
			transform.rotation = ball.transform.rotation;
		}
	}

	void ChangeView () {
		ball.SendMessage ("ChangeView");
		var pos = transform.position;
		pos.y = followBall ? 1 : 30;
		transform.position = pos;
		var rot = transform.rotation.eulerAngles ; 
		rot.x = followBall ? 0 : 90;
		if (!followBall) rot.y = 0;
		transform.rotation = Quaternion.Euler(rot);
	}

	void ChaseBall () {
		var pos = ball.transform.position;
		pos.y = transform.position.y;
		transform.position = Vector3.MoveTowards(transform.position, pos, 1);
	}

	void MoveCamera () {
		if (Input.GetKey(KeyCode.Keypad8))
			transform.Translate(0,speed,0);
		
		if (Input.GetKey(KeyCode.Keypad2))
			transform.Translate(0,-speed,0);
		
		if (Input.GetKey(KeyCode.Keypad4))
			transform.Translate(-speed,0,0);
		
		if (Input.GetKey(KeyCode.Keypad6))
			transform.Translate(speed,0,0);
		
		if (Input.GetKey(KeyCode.Keypad5))
			ChaseBall ();
		
		if (Input.GetKey(KeyCode.KeypadMinus))
			if (transform.position.y > 5)
				transform.Translate(0,0,speed);
		
		if (Input.GetKey(KeyCode.KeypadPlus))
			if (transform.position.y < 50)
				transform.Translate(0,0,-speed);
	}

	void AngleCamera () {
		if (Input.GetKey(KeyCode.Keypad8))
			transform.Rotate(-speed,0,0);			
		
		if (Input.GetKey(KeyCode.Keypad2))
			transform.Rotate(speed,0,0);			
		
		if (Input.GetKey(KeyCode.Keypad4))
			transform.Rotate(0,-speed,0);			
		
		if (Input.GetKey(KeyCode.Keypad6))
			transform.Rotate(0,speed,0);
	}
	
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.V))
		{
			followBall = !followBall;
			ChangeView();
		}
		
		if (!followBall)
			if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
				AngleCamera();
			else
				MoveCamera();
	}
}
