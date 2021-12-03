using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalToolTip : MonoBehaviour
{
    // Start is called before the first frame update
    private Text myText;
    private Animal myAnimal;

    public String CustomTip;
    void Start()
    {
        myText = GetComponentInChildren<Text>();
        myAnimal = GetComponentInParent<Animal>();

        if (CustomTip == "")
        {
            myText.text = myAnimal.type.ToString();
        }
        else
        {
            myText.text = CustomTip;

        }
        
        gameObject.SetActive(false);
        
        
    }
    
    

    
}
