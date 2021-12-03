using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToolTip : MonoBehaviour
{
    // Start is called before the first frame update
    private Text myText;
    private Item myItem;
    void Start()
    {
        myText = GetComponentInChildren<Text>();
        myItem = GetComponentInParent<Item>();

        myText.text = myItem.type.ToString();
        
        gameObject.SetActive(false);
        
        
    }

    private void OnEnable()
    {
        transform.eulerAngles = Vector3.zero;
    }

}
