using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class SpecialPathedMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float RunSpeed;
    
    public bool Stop = false;
    public bool Activated = true;

    private float speed;
    private Vector3 MoveDirection;
    
    private Animator _am;

    private bool Moving;
    
    private Rigidbody _rb;

    public GameObject myPath;
    private Transform[] myPoints;
    private Transform currentTarget;
    private Transform lastTarget;
    private Transform lastLastTarget;


    public GameObject Player;
    public float FollowDistance;
    private float waitTimeCheck = 2f;
    public bool paused = false;
    private int index = 0;
    public GameObject[] texts;

    void Start()
    {
        _am = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody>();

        
        myPoints = myPath.GetComponentsInChildren<Transform>();
        foreach (var VARIABLE in texts)
        {
            VARIABLE.SetActive(false);
        }
        
        


    }

    // Update is called once per frame
    void Update()
    {

       
        
        if(!Stop  && Activated)
        {
            

            if (speed > 0)
            {
                Vector3 target = new Vector3(currentTarget.position.x, transform.position.y,
                    currentTarget.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target,
                    speed * Time.deltaTime);
                transform.LookAt(target);



            }

            if (new Vector2(transform.position.x - currentTarget.position.x, transform.position.z - currentTarget.position.z).magnitude <= 1)
            {
                if (currentTarget.name == myPoints[myPoints.Length - 1].name)
                {
                    _am.SetFloat("movement", 0);
                    Activated = false;
                    AnimalFollow _AF = GetComponent<AnimalFollow>();
                    _AF.objectToFollow = Player.transform;
                    _AF.following = true;

                }
                else
                {
                    GetClosestPoint();

                }
            }
            _am.SetFloat("movement", speed);
            
            if(!paused)
            {
                if (Vector3.Distance(Player.transform.position, transform.position) > FollowDistance)
                {
                    Pause();
                }
            }
            else
            {
                waitTimeCheck -= Time.deltaTime;
                if (waitTimeCheck < 0)
                {
                    waitTimeCheck = 2f;
                    if (Vector3.Distance(Player.transform.position, transform.position) < FollowDistance)
                    {
                        StartAgain();
                    }
                }
            }
        }

        
        

       


        
           
        
    }
    
    public IEnumerator WaitThenRemoveText(GameObject ActivatedObj)
    {
        ActivatedObj.SetActive(true);
        yield return new WaitForSeconds(10f);
        if (index < texts.Length - 1)
        {
            index += 1;
            StartCoroutine(WaitThenRemoveText(texts[index]));

        }
        else
        {
            index = 0;
        }
        ActivatedObj.SetActive(false);

        
        
    }
    public void ActivateNextText()
    {
        StartCoroutine(WaitThenRemoveText(texts[index]));
    }

    void Pause()
    {
        speed = 0;
        paused = true;
        _am.SetFloat("movement", 0);
        //ActivateNextText();
        //activate follow script agina?
        AnimalFollow _af = GetComponent<AnimalFollow>();
        _af.special = true;
        _af.objectToFollow = Player.transform;
        _af.following = true;
        _af.SpecialTriggered = false;
        Activated = false;


    }

    void StartAgain()
    {
        speed = RunSpeed;
        paused = false;
        StopAllCoroutines();
        foreach (var VARIABLE in texts)
        {
            VARIABLE.SetActive(false);
        }
    }

    

    public void StopPathedMovement()
    {
        Stop = true;
        speed = 0;
    }

    public void GetClosestPoint()
    {
        Transform closestPoint = myPoints[myPoints.Length - 1];
        foreach (Transform point in myPoints)
        {
            if (point != currentTarget && point != lastTarget && point.name != "Final" && point != lastLastTarget && point.gameObject.activeSelf)
            {
                float dist1 = new Vector2(transform.position.x - point.position.x, transform.position.z - point.position.z)
                    .magnitude;
                float closest = new Vector2(transform.position.x - closestPoint.position.x, transform.position.z - closestPoint.position.z)
                    .magnitude;
                if (dist1 < closest)
                {
                    closestPoint = point;
                }
            }

           
        }


        if (lastLastTarget.name != myPath.name)
        {
            lastLastTarget.gameObject.SetActive(false);
        }

        lastLastTarget = lastTarget;
        lastTarget = currentTarget;
        currentTarget = closestPoint;
        

    }

    public void Activate()
    {
        deactivatePoints();
        currentTarget = myPoints[0];
        lastTarget = myPoints[0];
        lastLastTarget = myPoints[0];
        GetClosestPoint();
        Activated = true;
        speed = RunSpeed;

    }

    private void deactivatePoints()
    {
        //get rd of all points that are further away from the final as I am. 
        foreach (var VARIABLE in myPoints)
        {
            if (VARIABLE.name != myPath.name)
            {
                float dist1 = new Vector2(myPoints[myPoints.Length - 1].position.x - VARIABLE.position.x, myPoints[myPoints.Length - 1].position.z - VARIABLE.position.z)
                    .magnitude;
                float dist2 = new Vector2(transform.position.x - myPoints[myPoints.Length - 1].position.x, transform.position.z - myPoints[myPoints.Length - 1].position.z)
                    .magnitude;

                if (dist1 > dist2)
                {
                    VARIABLE.gameObject.SetActive(false);
                }
            }
        }
        
    }
    
}
