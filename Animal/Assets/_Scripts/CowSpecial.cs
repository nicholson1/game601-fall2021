using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpecial : AnimalQuestSpecial
{
    private bool bucketOnHead;
    private GameObject bucket;
    private AnimalRandomMovement _ARM;
    public Transform head;
    public Vector3 posOffset;
    public Vector3 rotationOffset;
    public GameObject Buckettext;
    public GameObject PostQuestText;

    private void Start()
    {
        _ARM = GetComponent<AnimalRandomMovement>();
        Buckettext.SetActive(false);
        PostQuestText.SetActive(false);
    }

    public override void QuestSpecialAction(GameObject[] req)
    {
        bucket = req[0];
        bucket.GetComponent<Item>().enabled = false;
        _ARM.SpecificMovment(bucket.transform.position, 10);
        Buckettext.SetActive(true);
        StartCoroutine(WaitThenBucket());


        //Debug.Log("cow special");
        

    }
    public IEnumerator WaitThenBucket()
    {
        transform.LookAt(bucket.transform);
        _ARM.Pause();
        yield return new WaitForSeconds(3f);
        MoveBucket();
        Buckettext.SetActive(false);
        GetComponent<AnimalInteract>().textBox = PostQuestText;
        _ARM.GetRandomPosition();
        _ARM.Stop = false;


    }

    private void MoveBucket()
    {
        bucket.GetComponent<Rigidbody>().detectCollisions = false;
        bucket.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        bucket.transform.SetParent(head);
        bucket.transform.localPosition = posOffset;
        bucket.transform.localEulerAngles = rotationOffset;
        bucket.transform.localScale = new Vector3(.75f, .75f, .75f);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (!bucketOnHead)
        {
            if (other.gameObject == bucket)
            {
                _ARM.StopARM();
                /// do the thing
                GetComponentInChildren<Animator>().SetTrigger("eat");

                StartCoroutine(WaitThenBucket());
                



            }
        }
       
    }
}
