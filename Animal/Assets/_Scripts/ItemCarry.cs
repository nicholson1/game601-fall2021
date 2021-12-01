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


}
