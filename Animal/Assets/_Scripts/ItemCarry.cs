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
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DropItem1();
            }
        }
        if (item2 != null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
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
        item1.transform.position = transform.parent.position + Vector3.forward + Vector3.up;

        item1.transform.SetParent(transform.parent.parent);
        item1.Drop();
        item1 = null;
    }
    private void DropItem2()
    {        
        item2.transform.position = transform.parent.position + Vector3.forward + Vector3.up;

        item2.transform.SetParent(transform.parent.parent);
        item2.Drop();

        item2 = null;
    }


}
