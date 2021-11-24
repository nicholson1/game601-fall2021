using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleHit : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem ps;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // private void OnParticleCollision(GameObject other)
    //
    //
    // {
    //     Debug.Log(other.tag);
    //
    //     if (other.CompareTag("Player"))
    //     {
    //         Debug.Log("hit player");
    //     }
    // }
}
