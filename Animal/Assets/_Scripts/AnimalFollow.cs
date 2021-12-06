using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public bool following = false;
    public Transform objectToFollow;
    public float speed;

    private Vector3 targetPos;
    private Animator _am;
    private Vector3 offset;

    public Item.Itemtype[] itemsToFollow;

    private Rigidbody _rb;
    private bool is_following;
    public bool DontNeedItem = false;
    public bool special = false;

    private bool SpecialTriggered;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _am = GetComponentInChildren<Animator>();
    }

    public bool CorrectItem(Item.Itemtype item)
    {
        if (itemsToFollow.Contains(item))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void Update()
    {
        if (is_following != following)
        {
            is_following = following;
            offset = new Vector3(Random.Range(-.5f,.5f), 0, Random.Range(-.5f,.5f));
            
        }
        
        
        if (following)
        {
            
            if (objectToFollow != null)

            {
                if (special)
                {
                    speed = Vector3.Distance(transform.position, objectToFollow.position)/3 + 1;
                }

                
                targetPos = new Vector3(objectToFollow.transform.position.x, transform.position.y,
                    objectToFollow.transform.position.z);
                if (Vector3.Distance(targetPos + Vector3.back + offset, transform.position) > 4)
                {
                    if (!special)
                    {
                        _am.SetFloat("movement", speed);
                    }
                    else
                    {
                        _am.SetFloat("movement", 6);

                    }
                    transform.LookAt(targetPos);
                    transform.position = Vector3.MoveTowards(transform.position , targetPos + Vector3.back +offset, speed * Time.deltaTime);
                }
                else
                {
                    _am.SetFloat("movement", 0);

                    if (special && !SpecialTriggered)
                    {
                        GetComponent<WolfTalking>().ActivateNextText();
                        SpecialTriggered = true;
                        following = false;
                        objectToFollow = null;
                        SelectBestPath();
                    }

                }

                
            }
        }
    }

    private void SelectBestPath()
    {
        GetComponent<SpecialPathedMovement>().Activate();
    }
}
