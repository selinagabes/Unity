using UnityEngine;
using System.Collections;

public class DeathZoneSpin : MonoBehaviour {

    public float _speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 90,  0) * Time.deltaTime * _speed);
    }
}
