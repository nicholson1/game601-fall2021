using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    // Start is called before the first frame update
    private levelManager _levelManager;
    public GameObject Johnny;
    public GameObject Balloon;

    private bool releasedBalloon = false;
    void Start()
    {
        _levelManager = FindObjectOfType<levelManager>();
    }

    private void Update()
    {
        if (_levelManager.JumpsRemaining < 0 && !releasedBalloon )
        {
            //play door opening animation
            MakeBallon();
            releasedBalloon = true;
        }
    }


    // Update is called once per frame
    public void MakeJohnny()
    {
        Instantiate(Johnny, transform.position, Johnny.transform.rotation);
    }
    public void MakeBallon()
    {
        GameObject ball = Instantiate(Balloon, transform.position, Balloon.transform.rotation);
        ball.GetComponent<Balloon>()._player = GameObject.FindObjectOfType<playerScript>().transform; 
    }
}
