using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public float followSpeed = 1;
    public bool follow = true;

    public void Start()
    {
        Player = FindObjectOfType<playerScript>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (follow)
        {
            float dist = Vector2.Distance(Player.position, transform.position);
            //Debug.Log(dist);
            followSpeed = dist * dist + 2;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3( Player.position.x, Player.position.y, -10), Time.deltaTime * followSpeed);

        }
        
    }
}
