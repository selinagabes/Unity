using UnityEngine;
using System.Collections;
using System;

public class MoveIt : MonoBehaviour {

    // Use this for initialization
    private Vector3 position1 = new Vector3(2, 1, 0);
    private Vector3 position2 = new Vector3(-2, 1, 0);
    public float speed = 1.0f;
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(position2, position1, (Mathf.Sin(Time.time*speed) + 1f) / 2f);
	}
}
