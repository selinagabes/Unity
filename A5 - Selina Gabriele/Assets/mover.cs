using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Update () {

        float x0 = -transform.position.normalized.x;
        float y0 = -transform.position.normalized.y;
        GetComponent<Rigidbody>().AddForce(x0, y0, 0f, ForceMode.Force);
    }
}
