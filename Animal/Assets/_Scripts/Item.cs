using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Itemtype type;
    public GameObject ToolTip;
    public GameObject Model;
    
    //public Transform parentToSet;
    public Vector3 offsetPos;
    public Vector3 offsetRot;
    public Vector3 offsetScale;
    private bool moved = false;


    public void Start()
    {
        GameObject model = Instantiate(Model, transform);
        model.name = "ItemModel";
        model.transform.rotation = transform.rotation;
    }

    public void PickupItem(Transform parentToSet)
    {
        if(!moved)
        
        {
            transform.SetParent(parentToSet);
            transform.localPosition = Vector3.zero + offsetPos;
            transform.localEulerAngles = Vector3.zero + offsetRot;
            transform.localScale = Vector3.one + offsetScale;
            moved = true;
            CloseToolTip();
            
        }

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
        Bread
    }
}
