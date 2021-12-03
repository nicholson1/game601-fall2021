using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _am = GetComponentInChildren<Animator>();
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
                targetPos = new Vector3(objectToFollow.transform.position.x, transform.position.y,
                    objectToFollow.transform.position.z);
                if (Vector3.Distance(targetPos + Vector3.back + offset, transform.position) > 4)
                {
                    _am.SetFloat("movement", speed);
                    transform.LookAt(targetPos);
                    transform.position = Vector3.MoveTowards(transform.position , targetPos + Vector3.back +offset, speed * Time.deltaTime);
                }
                else
                {
                    _am.SetFloat("movement", 0);

                }

                
            }
        }
    }
}
