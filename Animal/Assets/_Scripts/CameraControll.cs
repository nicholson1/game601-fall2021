using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        //camera zoom
        float zoom = (Input.GetAxis("Mouse ScrollWheel"));
        if (zoom != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                transform.parent.position + new Vector3(0, 1, 0), zoom * 5 );
        }
        //camera roatate;
        if(Input.GetMouseButton(0))
        {
            
            transform.RotateAround(transform.parent.position + new Vector3(0, 1, 0), transform.up, Input.GetAxis("Mouse X")*5f);
            transform.RotateAround(transform.parent.position + new Vector3(0, 1, 0), transform.right,-Input.GetAxis("Mouse Y") * 5f);

            transform.eulerAngles =  new Vector3(transform.eulerAngles.x, transform.eulerAngles.y ,0);

            if (Input.GetMouseButton(1))
            {
                //transform.parent.LookAt(new Vector3(transform.position.x, transform.parent.position.y, -transform.position.z));
                transform.parent.GetComponent<PlayerMovement1>().moveAmount = Vector3.forward;
                
                //Vector3 difference = new Vector3(transform.parent.position.x - transform.position.x, transform.parent.position.y - transform.position.y ,transform.parent.position.z - transform.position.z );
                //transform.localPosition = difference;

                //transform.localPosition = new Vector3(0, 2, -5);
                //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, 0);
                //transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);

                //transform.LookAt(transform.parent.position + new Vector3(0, 1, 0));
            }

        }

        

    }

}
