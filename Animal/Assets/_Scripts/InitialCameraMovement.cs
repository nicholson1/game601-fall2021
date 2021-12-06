using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class InitialCameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform otherCameraPos;
    public Transform player;


    public float speed;
    public bool zoomIn;
    public Camera fov;
    public float fovChangeAmount;
    private float fovTarget;
    public bool go;
    public GameObject menuCanvas;
    public WolfTalking dog;
    public GameObject Butterflies;

    private void Start()
    {
        transform.LookAt(player.position + new Vector3(0, 2, 0));

        otherCameraPos.gameObject.SetActive(false);
        fovTarget = otherCameraPos.GetComponent<Camera>().fieldOfView;
        fov = GetComponent<Camera>();
        player.GetComponent<PlayerMovement1>().enabled = false;
        
        //player.GetComponentInChildren<CameraControll>().enabled = false;
    }

    private void FixedUpdate()
    {
        if (go)
        {
            speed = Mathf.Sqrt(Vector3.Distance(transform.position, otherCameraPos.position)) + 3;
            if(zoomIn)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, otherCameraPos.position, speed * Time.deltaTime);

            

                if (Vector3.Distance(transform.position, otherCameraPos.position) < .1f)
                {
                    zoomIn = false;
                }
            

                transform.LookAt(player.position + new Vector3(0, 2, 0));
            }
            if (fov.fieldOfView > fovTarget)
            {
                fov.fieldOfView -= fovChangeAmount * Time.deltaTime;
            }
            else
            {
                fov.fieldOfView = fovTarget;
                if (!zoomIn)
                {
                    FinishedZoom();

                }

            }
        }
        
        

        
    }

    private void FinishedZoom()
    {
        
        otherCameraPos.gameObject.SetActive(true);
        player.GetComponent<PlayerMovement1>().enabled = true;
        player.GetComponentInChildren<CameraControll>().enabled = true;

        dog.ActivateNextText();
        gameObject.SetActive(false);
    }

    public void BeginZoom()
    {
        go = true;
        menuCanvas.SetActive(false);
        Butterflies.SetActive(false);

    }

}
