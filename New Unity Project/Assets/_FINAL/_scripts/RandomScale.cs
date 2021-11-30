using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    public float timeToChange = 0;
    public bool changing;
    private float targetScale;
    public bool ChangeOnStart;
    public bool Chaos = false;
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
                if (Chaos)
                {
                    targetScale = Random.Range(0.6f, 1.4f);
                }
                else
                {
                    targetScale = Random.Range(0.8f, 1.2f);

                }
            } 
        }
        else
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(targetScale, targetScale, 0), .075f * Time.deltaTime );
            if (Vector3.Distance(transform.localScale, new Vector3(targetScale, targetScale, 0)) < .01)
            {
                changing = false;
                if (Chaos)
                {
                    timeToChange = Random.Range(1, 3);

                }
                else
                {
                    timeToChange = Random.Range(3, 5);

                }

            }
        }
        
    }
}
