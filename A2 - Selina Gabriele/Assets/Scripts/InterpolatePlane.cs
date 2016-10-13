using UnityEngine;
using System.Collections;
using System;

public class InterpolatePlane : MonoBehaviour
{

    // Use this for initialization
    public Vector3 position1;
    public Vector3 position2;     
    public float _speed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(position2, position1, (Mathf.Sin(Time.time * _speed) + 1f) / 2f);
    }
}
