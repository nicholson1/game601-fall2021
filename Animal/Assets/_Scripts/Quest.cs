using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject[] Requirments;
    public float MaxDistanceForReq;
    public GameObject QuestIcon;

    public bool Completed;
    public GameObject CompleteQuestParticle;
    public bool AllRequirments = true;

    public Transform CheckLocation;

    private QuestTracker _questTracker;
    private void Update()
    {
        CheckIfComplete();
        
    }

    private void Start()
    {
        if (CheckLocation == null)
        {
            CheckLocation = transform;
        }

        _questTracker = FindObjectOfType<QuestTracker>();
    }

    private void CheckIfComplete()
    {
        bool OneInRange = false;
        foreach (GameObject req in Requirments)
        {
            
            if (Vector3.Distance(CheckLocation.position, req.transform.position) > MaxDistanceForReq)
            {
                if(AllRequirments)
                    return;
            }
            else
            {
                //if we are in range
                // are we on ground or in hand?
                Item item = req.GetComponent<Item>();
                if (item != null)
                {
                    if (item.pickedUp == true)
                    {
                        if(AllRequirments)
                            return;
                    }
                    else
                    {
                        OneInRange = true;

                    }
                }
            }

            
            //if we are an item, check to see if were on ground
            

            
        }

        if (!AllRequirments && !OneInRange)
        {
            return;
        }
        //if we never returned all objects should be close by
        //complete
        if (!Completed)
        {
            CompleteQuest();
        }
        
    }

    private void CompleteQuest()
    {
        Completed = true;
        // do somethign with text
        QuestIcon.SetActive(false);
        Instantiate(CompleteQuestParticle, transform);

        foreach (var VARIABLE in Requirments)
        {
            MovementCleanUp(VARIABLE);
        }
        MovementCleanUp(transform.parent.gameObject);

        GameObject player = GameObject.FindWithTag("Player");
        Instantiate(CompleteQuestParticle, player.transform);
        _questTracker.CompleteQuest();
        AnimalQuestSpecial _AQS = GetComponentInParent<AnimalQuestSpecial>();

        
        if (_AQS != null)
        {
            _AQS.QuestSpecialAction(Requirments);
        }
        //if anyone was following set follow = false;


        //do some action

    }

    private void MovementCleanUp(GameObject animal)
    {
        AnimalPathedMovement _APM = animal.GetComponent<AnimalPathedMovement>();
        AnimalFollow _AF = animal.GetComponent<AnimalFollow>();
        AnimalRandomMovement _ARM = animal.GetComponent<AnimalRandomMovement>();

        if (_APM != null)
        {
            _APM.Stop = true;
        }
        if (_AF != null)
        {
            _AF.following = false;
        }

        
        
        
        // //do after special
        //
        // if (_ARM != null)
        // {
        //     _ARM.Activated = true;
        //     _ARM.MaxDistance = 3;
        // }

    }


    //quest action
    //separate script
    //MoveRat( game object requirement){
    //moveToward object, then eat



}
