using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class AnimalRandomMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float WalkSpeed;
    public float RunSpeed;
    public float MaxDistance;

    public bool CanRun;

    public bool Stop = false;
    
    public float minWaitTime;
    public float maxWaitTime;
    
    public float minMoveTime;
    public float maxMoveTime;

    private float speed;
    private Vector3 MoveDirection;
    
    private Vector3 StartPosition;
    private Animator _am;
    private AnimalFollow _AF;

    private float TimeToNext;
    private bool Moving;
    private bool is_following;
    private Rigidbody _rb;

    void Start()
    {
        _am = GetComponentInChildren<Animator>();
        _AF = GetComponent<AnimalFollow>();
        StartPosition = transform.position;
        _rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        _am.SetFloat("movement", speed);

        if (is_following != _AF.following)
        {
            is_following = _AF.following;
            StartPosition = transform.position;
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
                transform.position = Vector3.MoveTowards(transform.position, transform.position + MoveDirection,
                    speed * Time.deltaTime);
                transform.LookAt(transform.position + MoveDirection);



            }

            if (Vector3.Distance(transform.position, StartPosition) >= MaxDistance)
            {
               // Debug.LogError("Too Far turn around");
                
                MoveDirection = new Vector3(StartPosition.x - transform.position.x, 0, StartPosition.z - StartPosition.z);
                //MoveDirection = new Vector3(MoveDirection.x *-1, 0, MoveDirection.y * -1).normalized;
                transform.LookAt(transform.position + MoveDirection);

                //speed = 0;


            }
        }
        
           
        
    }

    void RandomMove()
    {
        //Debug.Log("changing direction");
        int pick = Random.Range(1,4);
        MoveDirection = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5,5)).normalized;
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
        
        
        transform.LookAt(transform.position + MoveDirection);
        

    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Ground"))
        {
            //Debug.LogWarning("Hit Object");
            MoveDirection = new Vector3(-MoveDirection.x, 0, -MoveDirection.y).normalized;


            transform.LookAt(MoveDirection);
        }
    }

    public void StopARM()
    {
        Stop = false;
        speed = 0;

        
    }
}
