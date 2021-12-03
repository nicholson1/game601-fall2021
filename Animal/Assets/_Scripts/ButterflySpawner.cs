using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;
using Random = UnityEngine.Random;

public class ButterflySpawner : MonoBehaviour
{
    public Butterfly butterfly;

    public float rotateSpeed;
    public float particlePerSecond;

    public float timeAlive;
    private float timeToSpawn;

    private void Start()
    {
        timeToSpawn = 1 / particlePerSecond;

    }


    private void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0 )
        {
            Butterfly fly = Instantiate(butterfly, transform.position, transform.rotation);
            fly.speed = Random.Range(.5f, 3);
            fly.end = transform.position + new Vector3(Random.Range(-1, 1), 10, Random.Range(-1, 1));
            timeToSpawn = 1 / particlePerSecond;

        }

        transform.RotateAround(transform.parent.position, transform.up, rotateSpeed * Time.deltaTime);

        timeAlive -= Time.deltaTime;
        if (timeAlive < 0)
        {
            //timeAlive = 1.2f;
            //gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
