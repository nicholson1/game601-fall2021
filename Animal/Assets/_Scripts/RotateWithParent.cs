using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithParent : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initialRotation;
    private Vector3 initialPos;

    private void Start()
    {
        initialRotation = transform.localEulerAngles;
        initialPos = transform.localPosition;
    }

    private void FixedUpdate()
    {
        transform.eulerAngles = transform.parent.eulerAngles + initialRotation;
        //transform.position = transform.parent.position + initialPos;
    }
}
