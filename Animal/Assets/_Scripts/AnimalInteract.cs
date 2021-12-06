using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInteract : MonoBehaviour
{
    public GameObject textBox;
    //private bool rotateTowardPlayer = false;
    //private float rotateSpeed = .001f;
    //private Quaternion targetRotation;

    // Start is called before the first frame update
    private Animator _am;

    public GameObject ToolTip;

    private AnimalRandomMovement _ARM;
    private AnimalPathedMovement _APM;
    public bool canInteract = true;

    private void Start()
    {
        textBox.SetActive(false);
        _am = GetComponentInChildren<Animator>();
        _ARM = GetComponent<AnimalRandomMovement>();
        _APM = GetComponent<AnimalPathedMovement>();
    }

    public void Interact(Transform playerPosition)
    {
        if (_ARM != null)
        {
            _ARM.StopARM();
        }
        if (_APM != null)
        {
            _APM.StopPathedMovement();
        }
        // rotate tword the person
        CloseToolTip();
        Vector3 playerPos = new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z);
        transform.LookAt(playerPos, Vector3.up);
        _am.SetTrigger("eat");
        textBox.GetComponent<RotateTextBoxToCamera>().CameraPos = playerPosition.GetComponentInChildren<Camera>().transform;
        textBox.SetActive(true);

        
        
        
        // targetRotation = Quaternion.LookRotation(playerPos, Vector3.up);
        // rotateTowardPlayer = true;

    }
    
    public void ShowToolTip(Transform playerPosition)
    {
        
        ToolTip.GetComponent<RotateTextBoxToCamera>().CameraPos = playerPosition.GetComponentInChildren<Camera>().transform;
        //tool tip text . set active(true)
        ToolTip.SetActive(true);
    }

    public void CloseToolTip()
    {
        ToolTip.SetActive(false);
        // tool tip text .set active false
    }

    public void Disengage()
    {
        CloseToolTip();

        textBox.SetActive(false);
        if (_ARM != null)
        {
            _ARM.Stop = false;
        }
        if (_APM != null)
        {
            _APM.Stop = false;
        }


    }

  


    private void Update()
    {
        // if (rotateTowardPlayer)
        // {
        //     var step = rotateSpeed * Time.deltaTime;
        //
        //     // Rotate our transform a step closer to the target's.
        //     transform.parent.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
        //
        //     if (transform.parent.rotation == targetRotation)
        //     {
        //         rotateTowardPlayer = false;
        //     }
        // }
    }
}
