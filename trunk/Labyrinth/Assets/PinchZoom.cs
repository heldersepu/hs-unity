using UnityEngine;
using System.Collections;

public class PinchZoom : MonoBehaviour
{
	public float Speed = 0.1f;
	
	void Update()
	{
		// If there are two touches on the device...
		if (Input.touchCount == 2) 
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);
			
			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
			
			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
			
			// Find the difference in the distances between each frame.
			float mDiff = touchDeltaMag - prevTouchDeltaMag;
			float y = transform.position.y;

			Ray ray = camera.ScreenPointToRay((touchZeroPrevPos + touchOnePrevPos)/2);
			var pos = new Vector3(ray.origin.x, y, ray.origin.z);	

			transform.position = Vector3.MoveTowards(transform.position, pos, 1);
			if (((mDiff < 0) && (y < 50)) || ((mDiff > 0) && (y > 5)))
				transform.Translate(0,0, mDiff * Speed);
		}
	}
}
