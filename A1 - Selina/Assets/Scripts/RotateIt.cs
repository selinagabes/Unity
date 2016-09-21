using UnityEngine;
using System.Collections;

public class RotateIt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Time.deltaTime * 30, Time.deltaTime * 60, Time.deltaTime * 90);
	}
}
