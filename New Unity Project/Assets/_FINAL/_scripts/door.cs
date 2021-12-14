using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class door : MonoBehaviour
{
    private levelManager _levelManager;
    private Animator _am;
    public GameObject nextlevelTrigger;

    private void Start()
    {
        _levelManager = FindObjectOfType<levelManager>();
        _am = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _am.SetTrigger("open");
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _am.SetTrigger("close");
        }
    }

    public void Activate()
    {
        nextlevelTrigger.SetActive(true);
        //GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    public void Deactivate()
    {
        nextlevelTrigger.SetActive(false);
        //GetComponent<SpriteRenderer>().sortingOrder = -1;


    }
    
    

    //load scene 1
    
    
    

   

}
