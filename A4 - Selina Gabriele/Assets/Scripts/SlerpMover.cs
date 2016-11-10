using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlerpMover : MonoBehaviour {
    
    public Toggle IsAutomatic;
    public Scrollbar FractionTrip;
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (IsAutomatic.isOn)
            FractionTrip.interactable = false;
        if (!IsAutomatic.isOn)
            FractionTrip.interactable = true; 
    }
}
