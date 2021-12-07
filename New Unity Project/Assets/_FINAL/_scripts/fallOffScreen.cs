using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallOffScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private levelManager _levelManager;
    private void Start()
    {
        _levelManager = FindObjectOfType<levelManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Player"))
        {
            _levelManager.RestartLevel();
        }
    }

   
}
