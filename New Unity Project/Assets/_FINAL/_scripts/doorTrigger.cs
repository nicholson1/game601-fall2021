using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private levelManager _levelManager;
    void Start()
    {
        _levelManager = FindObjectOfType<levelManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            _levelManager.LoadNextLevel();
    }
}
