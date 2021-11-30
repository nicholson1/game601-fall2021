using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform _player;
    private levelManager _levelManager;    
    private float modifySpeed = 0;
    private bool triggered = false;
    public bool death = false;
    public bool up = false;


    public float speed = .001f;
    void Start()
    {
        _levelManager = FindObjectOfType<levelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!up)
        {
            if (_player != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _player.position + new Vector3(0,1f,0), speed * Time.deltaTime);
                modifySpeed += .001f;
                if (!death)
                {
                    speed = (_levelManager.JumpsRemaining * -1) + modifySpeed;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.one, speed * Time.deltaTime);

            if (!triggered && transform.position.y > _levelManager._mainCamera.transform.position.y + 15)
            {
                //i am now off the screen, lets restart the level?
                _levelManager.RestartLevel();
                triggered = true;
            }

        }

}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("death"))
        {
            other.transform.SetParent(this.transform);
            other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            up = true;
            GetComponentInChildren<Animator>().SetTrigger("pull");
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerScript>().PlayerDeath();
        }
    }
}
