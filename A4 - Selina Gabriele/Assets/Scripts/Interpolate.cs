using UnityEngine;
using System.Collections;

public class Interpolate : MonoBehaviour {
   
    public GameObject slerper; 

  
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(slerper.transform.position.x, transform.position.y, transform.position.z);
    }
}
