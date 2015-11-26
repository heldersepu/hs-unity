using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public Vector3 v ;
	public Vector3 a = new Vector3(0, -10, 0);
    public bool right = true;

	void Start () {
		Destroy(this.gameObject, 3);
		float y = Random.Range (-1f, 10f);
		v = new Vector3(20, y, 0);
        if (!right)
            v.x = -v.x;
	}

	void Update () {	
		transform.position += v*Time.deltaTime;
		v += a * Time.deltaTime;        
       	transform.rotation = Quaternion.LookRotation(v, new Vector3(0,0,-1));
	}
}
