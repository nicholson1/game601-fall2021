using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    private float timeToChange = 0;
    public bool changing;
    private float targetScale;
    public bool ChangeOnStart;
    void Start()
    {
        if(!ChangeOnStart)
            timeToChange = Random.Range(2, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (!changing)
        {
            timeToChange -= Time.deltaTime;
        
            if (timeToChange < 0)
            {
                changing = true;
                targetScale = Random.Range(0.75f, 1.25f);
            } 
        }
        else
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(targetScale, targetScale, 0), .1f * Time.deltaTime );
            if (Vector3.Distance(transform.localScale, new Vector3(targetScale, targetScale, 0)) < .01)
            {
                changing = false;
                timeToChange = Random.Range(1, 5);

            }
        }
        
    }
}
