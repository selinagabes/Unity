﻿using UnityEngine;
using System.Collections;

public class RotateIt : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( new Vector3(30,15,45) *Time.deltaTime);
    }
}
