using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTextBoxToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform CameraPos;
    private float distance;
    public bool adjustPos = false;
    private void Start()
    {
        CameraPos = FindObjectOfType<Camera>().transform;
        RectTransform _RT = GetComponent<RectTransform>();
        if (_RT != null)
        {
            distance = GetComponent<RectTransform>().localPosition.y;
        }
        else
        {
            distance = transform.localPosition.y;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(CameraPos, Vector3.up);
        if(adjustPos)
            transform.position = transform.parent.position + new Vector3(0, distance, 0);
    }
}
