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


    private void Start()
    {
        textBox.SetActive(false);
    }

    public void Interact(Transform playerPosition)
    {
        // rotate tword the person
        Vector3 playerPos = new Vector3(playerPosition.position.x, transform.parent.position.y, playerPosition.position.z);
        transform.parent.LookAt(playerPos, Vector3.up);
        GetComponentInParent<Animator>().SetTrigger("eat");
        textBox.GetComponent<RotateTextBoxToCamera>().CameraPos = playerPosition.GetComponentInChildren<Camera>().transform;
        textBox.SetActive(true);
        // targetRotation = Quaternion.LookRotation(playerPos, Vector3.up);
        // rotateTowardPlayer = true;

    }

    public void Disengage()
    {
        textBox.SetActive(false);
        GetComponentInParent<Animator>().SetTrigger("eat");


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
