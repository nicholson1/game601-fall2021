using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AnimalFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public bool following = false;
    public Transform objectToFollow;
    public float speed;

    private Vector3 targetPos;
    private Animator _am;

    public Item.Itemtype[] itemsToFollow;

    
    
    private void Update()
    {
        if (_am == null)
        {
            _am = GetComponentInChildren<Animator>();
        }
        else if (following)
        {
            if (objectToFollow != null)

            {
                targetPos = new Vector3(objectToFollow.transform.position.x, transform.position.y,
                    objectToFollow.transform.position.z);
                if (Vector3.Distance(targetPos + Vector3.back, transform.position) > 4)
                {
                    _am.SetFloat("movement", 1);
                    transform.LookAt(targetPos);
                    transform.position = Vector3.MoveTowards(transform.position , targetPos + Vector3.back, speed * Time.deltaTime);
                }
                else
                {
                    _am.SetFloat("movement", 0);

                }

                
            }
        }
    }
}
