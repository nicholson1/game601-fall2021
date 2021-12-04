using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class AnimalPathedMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float WalkSpeed;
    public float RunSpeed;

    public bool CanRun;

    public bool Stop = false;
    
    public float minWaitTime;
    public float maxWaitTime;
    
    public float minMoveTime;
    public float maxMoveTime;

    private float speed;
    private Vector3 MoveDirection;
    
    private Animator _am;
    private AnimalFollow _AF;

    private float TimeToNext;
    private bool Moving;
    private bool is_following;
    private Rigidbody _rb;

    public GameObject myPath;
    private Transform[] myPoints;
    private int currentIndex = 0;

    void Start()
    {
        _am = GetComponentInChildren<Animator>();
        _AF = GetComponent<AnimalFollow>();
        _rb = GetComponent<Rigidbody>();

        myPoints = myPath.GetComponentsInChildren<Transform>();
        


    }

    // Update is called once per frame
    void Update()
    {

        if (is_following != _AF.following)
        {
            is_following = _AF.following;
        }
        
        if(!Stop && !is_following)
        {
            TimeToNext -= Time.deltaTime;
            if (TimeToNext < 0)
            {
                RandomMove();
            }

            if (speed > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, myPoints[currentIndex].position,
                    speed * Time.deltaTime);
                transform.LookAt(new Vector3(myPoints[currentIndex].position.x, transform.position.y,
                    myPoints[currentIndex].position.z));



            }

            if (new Vector2(transform.position.x - myPoints[currentIndex].position.x, transform.position.z - myPoints[currentIndex].position.z).magnitude <= 2)
            {
               //pause
               Pause();
               
               currentIndex += 1;
               if (currentIndex > myPoints.Length - 1)
               {
                   currentIndex = 0;
               }
               


            }
        }
        if(!is_following && !Stop)
            _am.SetFloat("movement", speed);


        
           
        
    }

    void Pause()
    {
        speed = 0;
        _am.SetTrigger("eat");
        TimeToNext = maxWaitTime;
        
    }

    void RandomMove()
    {
        //Debug.Log("changing direction");
        int pick = Random.Range(1,4);
        //MoveDirection = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5,5)).normalized;
        if (pick == 1)
        {
            //idle
            speed = 0;
            _am.SetTrigger("eat");
            TimeToNext = Random.Range(minWaitTime, maxWaitTime);

        }
        else if (pick == 2)
        {
            //walk
            speed = WalkSpeed;
            TimeToNext = Random.Range(minMoveTime, maxMoveTime);

        }
        else
        {
            //run
            TimeToNext = Random.Range(minMoveTime, maxMoveTime);

            if (CanRun)
            {
                speed = RunSpeed;
            }
            else
            {
                speed = WalkSpeed;
            }

        }
        
        
        //transform.LookAt(transform.position + MoveDirection);
        

    }

    public void StopPathedMovement()
    {
        Stop = true;
        speed = 0;

        
    }
}
