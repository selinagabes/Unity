using UnityEngine;
using System.Collections;

public class ResizeIt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.localScale = new Vector3(Mathf.PingPong(Time.time, 3)+1, Mathf.PingPong(Time.time, 3)+1, Mathf.PingPong(Time.time, 3)+1);
	}
}
