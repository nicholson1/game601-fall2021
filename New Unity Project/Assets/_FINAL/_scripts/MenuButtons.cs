using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler
{

    //load scene 1
    public void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        
        //gameObject.GetComponent<Button>().
    }
    public Text theText;
    private bool onButton = false;
    public void OnPointerEnter(PointerEventData eventData)
    {         
        //Debug.Log("The cursor entered the selectable UI element.");
        theText.color = Color.yellow; //Or however you do your color
        onButton = true;

    }
    public void OnPointerExit(PointerEventData eventData) 
    {         
        theText.color = Color.white; //Or however you do your color 
        onButton = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        changeTextColor();
    }

    public void changeTextColor()
    {
        if(onButton)
            theText.color = new Color(.5f,.5f, 0f);
    }


}
