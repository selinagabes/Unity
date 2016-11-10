using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlerpToggle : MonoBehaviour {
    public Toggle Slerp1 ;
    public Toggle Slerp2 ;
    public Toggle Slerp3 ;

    public GameObject Slerper;

    void Start()
    {
        ActiveToggle();
    }
    public void ActiveToggle()
    {
        if (Slerp1.isOn)
        {
            Slerper.GetComponent<Slerper>()._passesThrough = new Vector3(0, 1, 0);
            Slerper.GetComponent<Slerper>()._isOnZAxis = false;

        }
        if (Slerp2.isOn) {

           
            Slerper.GetComponent<Slerper>()._passesThrough = new Vector3(0, -1, 0);
            Slerper.GetComponent<Slerper>()._isOnZAxis = false;
        }
        if (Slerp3.isOn)
        {
         
            Slerper.GetComponent<Slerper>()._passesThrough = new Vector3(0, 0, 1);
            Slerper.GetComponent<Slerper>()._isOnZAxis = true;
        }
    }
}
