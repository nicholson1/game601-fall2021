using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTextBoxToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform CameraPos;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(CameraPos, Vector3.up);
    }
}
