using UnityEngine;
using System.Collections;
using System;

public class MoveIt : MonoBehaviour {

    // Use this for initialization
  
	void Start () {
        //transform.position = new Vector3(transform.position.x-2, transform.position.y, transform.position.z);
}
	
	// Update is called once per frame
	void Update () {
        if(Time.time> Time.deltaTime)
            transform.position = new Vector3(PingPong(Time.time, 2, -2), transform.position.y, transform.position.z);
	}

    public float PingPong(float t,  float maxLength, float minLength)
    {
        return -(Mathf.PingPong(t, maxLength - minLength) + minLength);
    }
}
