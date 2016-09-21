using UnityEngine;
using System.Collections;
using System;

public class MoveIt : MonoBehaviour {

    // Use this for initialization
    private float startTime = 0.0F;

	void Start () {
        //transform.position = new Vector3(transform.position.x-2, transform.position.y, transform.position.z);
}
	
	// Update is called once per frame
	void Update () {
        
        transform.position = new Vector3(PingPong(Time.time-startTime, 2, -2), transform.position.y, transform.position.z);
	}

    public float PingPong(float t,  float maxLength, float minLength)
    {
        return -(Mathf.PingPong(t, maxLength - minLength) + minLength);
    }
}
