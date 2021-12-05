using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Itemtype type;
    public GameObject ToolTip;
   // public GameObject Model;
    
    //public Transform parentToSet;
    public Vector3 offsetPos;
    public Vector3 offsetRot;
    public Vector3 offsetScale;
    public bool pickedUp = false;


    public void Start()
    {
        // GameObject model = Instantiate(Model, transform);
        // model.name = "ItemModel";
        // model.transform.rotation = transform.rotation;
    }
    private Vector3 lastPosition;
    void FixedUpdate()
    {

        bool hit = Physics.Raycast(transform.position + new Vector3(0,.1f,0), Vector3.down, 10);

        if (hit)
        {
            this.lastPosition = transform.position;
        }
        else
        {
            //Debug.Log("we fell through" + gameObject.name);
            transform.position = new Vector3(transform.position.x, lastPosition.y +.05f , transform.position.z);
        }

    }

    public void Update()
    {
        if (pickedUp)
        {
            transform.localEulerAngles = Vector3.zero + offsetRot;
            transform.localPosition = Vector3.zero + offsetPos;
        }
         
    }

    public void PickupItem(Transform parentToSet)
    {
        if(!pickedUp)
        
        {
            GetComponentInChildren<MeshRenderer>().transform.eulerAngles = transform.eulerAngles;

            transform.SetParent(parentToSet);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<Rigidbody>().detectCollisions = false;

            transform.localPosition = Vector3.zero + offsetPos;
            transform.localEulerAngles = Vector3.zero + offsetRot;
            transform.localScale = Vector3.one + offsetScale;
            pickedUp = true;
            CloseToolTip();
            
        }

    }

    public void Drop(Transform player)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().detectCollisions = true;



        pickedUp = false;
        transform.eulerAngles = Vector3.zero;
        transform.SetParent(player.parent);

        //transform.localScale = transform.localScale - offsetScale;
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
    public enum Itemtype
    {
        Apple,
        Fish,
        Meat,
        Carrot,
        Medicine,
        Bread,
        Turnip,
        Cabbage,
        Cauliflower,
        Cheese,
        Pumpkin, 
        Bucket,
        Pear,

    }
}
