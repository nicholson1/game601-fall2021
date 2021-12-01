using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        float zoom = (Input.GetAxis("Mouse ScrollWheel"));
        if (zoom != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.parent.position + new Vector3(0,1,0), 1.5f/zoom *Time.deltaTime);
        }
    }

}
