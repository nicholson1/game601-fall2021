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
    public bool Activated = true;
    private bool SpecificMove = false;

    public Transform ThingToFollow;
    public bool FollowThing = false;

    void Start()
    {
        _am = GetComponentInChildren<Animator>();
        _AF = GetComponent<AnimalFollow>();
        StartPosition = transform.position;
        _rb = GetComponent<Rigidbody>();
        GetRandomPosition();
        
        


    }

    // Update is called once per frame
    void Update()
    {

        if (is_following != _AF.following)
        {
            is_following = _AF.following;
            StartPosition = transform.position;
            GetRandomPosition();
        }

        
        
        
        
        if(!Stop && !is_following && Activated)
        {
            _am.SetFloat("movement", speed);

            TimeToNext -= Time.deltaTime;
            if (TimeToNext < 0)
            {
                RandomMove();
            }

            if (speed > 0)
            {
                transform.LookAt(new Vector3(MoveDirection.x, transform.position.y, MoveDirection.z));

                transform.position = Vector3.MoveTowards(transform.position, MoveDirection,
                    speed * Time.deltaTime);
                //_am.SetFloat("movement", speed);

                //Debug.Log(new Vector2(transform.position.x - MoveDirection.x, transform.position.z - MoveDirection.z).magnitude);
                
                if (new Vector2(transform.position.x - MoveDirection.x, transform.position.z - MoveDirection.z).magnitude <= 1.5f)

                {
                    //Debug.Log("We at the target location");
                    //pause
                    Pause();
                    //new random direction;
                    GetRandomPosition();
                    if (SpecificMove)
                    {
                        SpecificMove = false;
                        //Debug.Log("specific move no more");
                    }
                
                    //MoveDirection = new Vector3(StartPosition.x - transform.position.x, 0, StartPosition.z - StartPosition.z);
                    //MoveDirection = new Vector3(MoveDirection.x *-1, 0, MoveDirection.y * -1).normalized;
                    //transform.LookAt(transform.position + MoveDirection);

                    //speed = 0;


                }



            }

            
        }
        
           
        
    }
    public void Pause(float SetTime = 0)
    {
        speed = 0;
        _am.SetTrigger("eat");
        if (SetTime == 0)
        {
            TimeToNext = maxWaitTime;
        }
        else
        {
            TimeToNext = SetTime;

        }
        _am.SetFloat("movement", speed);
        
    }

    public void GetRandomPosition()
    {
        MoveDirection = new Vector3(Random.Range(StartPosition.x - MaxDistance, StartPosition.x + MaxDistance), 0, Random.Range(StartPosition.z - MaxDistance, StartPosition.z + MaxDistance  ));
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
        if (FollowThing)
        {

            StartPosition = ThingToFollow.position;
            GetRandomPosition();
            
        }
        
        
        //transform.LookAt(transform.position + MoveDirection);
        

    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Ground") && !other.collider.CompareTag("Item") && Activated && !Stop)
        {
            //Debug.LogWarning("Hit Object");
            if (!SpecificMove)
            {
                Pause();
                GetRandomPosition();
                //MoveDirection = StartPosition + new Vector3(-MoveDirection.x, 0, -MoveDirection.y);

            }
            else
            {
                Pause(.2f);
            }


            //transform.LookAt(MoveDirection);
        }
    }

    public void StopARM()
    {
        Stop = true;
        speed = 0;

        
    }

    public void SpecificMovment(Vector3 target, float timeToChill)
    {
        speed = WalkSpeed;
        MoveDirection = target;
        transform.LookAt(MoveDirection);
        TimeToNext = timeToChill;
        _am.SetFloat("movement", speed);
        SpecificMove = true;
    }

    public void Activate(float timeToChill)
    {
        Activated = true;
        TimeToNext = timeToChill;
        _am.SetTrigger("eat");
        StartPosition = transform.position;
        GetRandomPosition();
    }
}
