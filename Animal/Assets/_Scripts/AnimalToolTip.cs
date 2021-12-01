using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalToolTip : MonoBehaviour
{
    // Start is called before the first frame update
    private Text myText;
    private Animal myAnimal;
    void Start()
    {
        myText = GetComponentInChildren<Text>();
        myAnimal = GetComponentInParent<Animal>();

        myText.text = myAnimal.type.ToString();
        
        gameObject.SetActive(false);
        
        
    }
    
    

    
}
