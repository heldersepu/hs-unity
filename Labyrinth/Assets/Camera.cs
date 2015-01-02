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
			var rot = ball.transform.rotation.eulerAngles ; 
			rot.z = 0;
			//transform.rotation = Quaternion.Euler(rot);
		}
	}
	
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.V))
		{
			followBall = !followBall;
			ball.SendMessage ("ChangeView");
			var rot = transform.rotation.eulerAngles ; 
			rot.z = followBall ? 0 : 90;
			transform.rotation = Quaternion.Euler(rot);
		}
		
		if (!followBall)
		{
			if(Input.GetKey(KeyCode.Keypad8))
				transform.Translate(0,speed,0);
			
			if(Input.GetKey(KeyCode.Keypad2))
				transform.Translate(0,-speed,0);
			
			if(Input.GetKey(KeyCode.Keypad4))
				transform.Translate(-speed,0,0);
			
			if(Input.GetKey(KeyCode.Keypad6))
				transform.Translate(speed,0,0);
			
			if(Input.GetKey(KeyCode.Keypad5))
			{
				var pos = ball.transform.position;
				if (pos.y < 10) pos.y = 10;
				transform.position = Vector3.MoveTowards (transform.position, pos, 1);
			}
			
			if(Input.GetKey(KeyCode.KeypadMinus))
				if (transform.position.y > 5)
					transform.Translate(0,0,speed);
			
			if(Input.GetKey(KeyCode.KeypadPlus))
				if (transform.position.y < 50)
					transform.Translate(0,0,-speed);
		}
	}
}
