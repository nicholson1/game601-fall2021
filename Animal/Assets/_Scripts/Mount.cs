using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mount : MonoBehaviour
{
    public bool CanMount = false;
    public Transform RidingPosition;
    public Transform DismountPosition;
    public bool mounted;

    public GameObject[] thingsToDeactivate;

    private Animator _am;
    private Rigidbody _rb;
    private PlayerMovement1 playerMovement;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _am = GetComponentInChildren<Animator>();
    }


    public void DoTheMount(GameObject player)
    {
        mounted = true;
        //set Position of player
        player.transform.position = RidingPosition.position;
        player.transform.rotation = RidingPosition.rotation;
        GetComponent<AnimalInteract>().canInteract = false;
        //set Rotation to this object
        //set this object to child of player
        transform.SetParent(player.transform);
        foreach (var VARIABLE in thingsToDeactivate)
        {
            VARIABLE.SetActive(false);
        }

        playerMovement = player.GetComponent<PlayerMovement1>();
        _rb.Sleep();
        GetComponent<AnimalRandomMovement>().Activated = false;

        
        //player.GetComponentInChildren<Animator>().transform.SetParent(RidingPosition);


    }

    public void DisMount()
    {
        mounted = false;


        //transform.parent.GetComponentInChildren<Animator>().transform.SetParent(transform.parent);

        //transform.parent.position = DismountPosition.position;
        //transform.parent.rotation = DismountPosition.rotation;
        GetComponent<AnimalInteract>().canInteract = true;


        transform.SetParent(playerMovement.transform.parent);

        
        foreach (var VARIABLE in thingsToDeactivate)
        {
            VARIABLE.SetActive(true);
        }
        GetComponent<AnimalRandomMovement>().Activate(3);
        //_rb
    }

    private void LateUpdate()
    {
        if (mounted)
        {
            transform.rotation = transform.parent.rotation;
            //transform.localPosition = Vector3.zero;
            //transform.parent.position = RidingPosition.position;


            //transform.parent.rotation = RidingPosition.transform.rotation;
            _am.SetFloat("movement", playerMovement.moveAmount.z) ;
            
            
        }
        
        
        
    }
}
