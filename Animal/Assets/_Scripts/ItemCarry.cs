using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCarry : MonoBehaviour
{
    //2 items
    //one in each hand
    // have types easy exceesable
    // drop items
    public Item item1;
    public Item item2;

    public Transform itemHand2;
    public Transform itemHand1;

    private Item interactItem;

    private AnimalCheck _animalCheck;

    public Transform dropPoint;

    private void Start()
    {
        _animalCheck = GetComponent<AnimalCheck>();
    }

    private void Update()
    {
        if (interactItem != null)
        {
            if (Input.GetButtonDown("Submit"))
            {
                //interactItem.Interact(transform.parent.transform);
                if (item1 == null)
                {
                    interactItem.PickupItem(itemHand1);
                    item1 = interactItem;
                    interactItem = null;
                }
                else if (item2 == null)
                {
                    interactItem.PickupItem(itemHand2);
                    item2 = interactItem;
                    interactItem = null;

                }
            }
        }

        if (item1 != null)
        {
            if (Input.GetButtonDown("dropItem1"))
            {
                DropItem1();
            }
        }
        if (item2 != null)
        {
            if (Input.GetButtonDown("dropItem2"))
            {
                DropItem2();
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (interactItem == null)
            {
                interactItem = other.GetComponent<Item>();
                interactItem.ShowToolTip(transform.parent);
                

            }
            
            //show tool tip?
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (interactItem == other.GetComponent<Item>())
            {
                //cancel tool tip;
                interactItem.CloseToolTip();
                interactItem = null;
            }
            
        }
    }

    private void DropItem1()

    {
        item1.transform.position = dropPoint.position;

        //item1.transform.position = transform.parent.position + Vector3.forward + Vector3.up;

        item1.Drop(transform.parent);
        item1 = null;
        CheckIfStillFollowing();
    }
    private void DropItem2()
    {        
        item2.transform.position = dropPoint.position;

        //item2.transform.position = transform.parent.position + transform.parent.rotation.eulerAngles.normalized + Vector3.up;

        item2.Drop(transform.parent);

        item2 = null;
        CheckIfStillFollowing();
    }
    
    public void CheckIfStillFollowing()
    {
        foreach (AnimalFollow animalFollow in _animalCheck.animalsFollowingMe)
        {
            //bool keepFolowing = false;

            if (item1 != null)
            {
                if (animalFollow.CorrectItem(item1.type))
                {
                    //keepFolowing = true;
                    break;
                }
            }
            if (item2 != null)
            {
                if (animalFollow.CorrectItem(item2.type))
                {
                    //keepFolowing = true;
                    break;
                }
            }
            animalFollow.following = false;


            
        }
    }


}
