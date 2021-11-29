using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class door : MonoBehaviour
{
    private levelManager _levelManager;

    private void Start()
    {
        _levelManager = FindObjectOfType<levelManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _levelManager.LoadNextLevel();
        }
    }

    //load scene 1
    
    
    

   

}
