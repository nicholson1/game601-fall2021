using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public float speed = .001f;
    void Start()
    {
        player = GameObject.FindObjectOfType<playerScript>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed += .001f;
    }
}
