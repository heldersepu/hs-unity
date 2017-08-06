using UnityEngine;

public class Movement : MonoBehaviour {
    public float force = 10f;

    Rigidbody rigBody { get { return GetComponent<Rigidbody>(); } }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
            rigBody.AddForce(Vector3.forward * force);

        if (Input.GetKey(KeyCode.DownArrow))
            rigBody.AddForce(Vector3.back * force);

        if (Input.GetKey(KeyCode.LeftArrow))
            rigBody.AddForce(Vector3.left * force);

        if (Input.GetKey(KeyCode.RightArrow))
            rigBody.AddForce(Vector3.right * force);
    }
}
