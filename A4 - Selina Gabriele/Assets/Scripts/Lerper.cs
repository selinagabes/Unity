using UnityEngine;
using System.Collections;

public class Lerper : MonoBehaviour {
    public Vector3 _start;	//Get a start position for the travel
    public Vector3 _end;		//Get an end position for the travel
    public float _lerpTotalTime = 1f;		//Speed of travel
    private float startTime;		//Time that the travel begins
    private float journeyLength;	//Journey distance

    void Start()
    {
        _start = new Vector3(-10, 0, 0);
        _end = new Vector3(10, 0, 0);// Function called on all objects after Awake (initialization function)
        startTime = Time.time;																		// Start time
        journeyLength = Vector3.Distance(_start, _end);					// Set the journey distance
    }

    void Update()
    {																					// Update is called once per frame				
        float fracJourney = (Time.time - startTime) * (_lerpTotalTime/journeyLength);													// Compute the fraction of the journey we are completing this frame
        transform.position = Vector3.Lerp(_start, _end, Mathf.PingPong(fracJourney, 1f));	// Get the new position for this frame by lerping
        // New position is on the line between the two positions provided, a fraction of the total journey distance
        Debug.Log("Update: " + Time.frameCount);
    }
}
