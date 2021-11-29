using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float runSpeed;
    public float jumpStrength;
    public GameObject deathObj;
    public GameObject balloon;
    Rigidbody2D rb;
    private Animator am;
    public Transform groundDetect;
    private bool onGround;
    private float moveDir;
    private float Red = 0;
    private levelManager _levelManager;


    private bool jumping =  false;
    private bool falling = false;
    private bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
        _levelManager = FindObjectOfType<levelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundDetect.position, -Vector2.up, 1f);

        if (hit.collider != null && hit.collider.CompareTag("ground"))
        {
            onGround = true;
            if (falling && Mathf.Abs(rb.velocity.y) < .25)
            {
                am.SetBool("jumping", false);
                falling = false;
            }
        }
        else
        {
            onGround = false;
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f )
        {
            moveDir = Input.GetAxis("Horizontal");
            am.SetBool("walking", true);
        }
        else
        {
            moveDir = 0;
            if( Mathf.Abs(rb.velocity.x) < .01f)
                am.SetBool("walking", false);
        }

        //if you presss right arrow, run to the right
        if (moveDir > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //if ypu press left arrow, run left
        else if (moveDir <0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (jumping)
        {
            if (rb.velocity.y < 0)
            {
                jumping = false;
                falling = true;
            }
        }

       
        

        //if you press space, jump
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) )
        {
            if (!attacking)
            {
                am.SetBool("jumping", true);
                if (falling && onGround)
                {
                    _levelManager.JumpTrigger();
                    rb.AddForce(transform.up * jumpStrength, ForceMode2D.Impulse);
                    _levelManager.UpdateText();



                }
                else if (onGround)
                {
                    _levelManager.JumpTrigger();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            am.SetBool("attacking", !attacking);
            
        }
       
    }

    public void Attacking()
    { 
        attacking = !attacking;
       //spawn trigger?
    }

    public void Jump()
    {
        if (onGround)
        {
            
            rb.AddForce(transform.up * jumpStrength, ForceMode2D.Impulse);
            jumping = true;
            _levelManager.UpdateText();

        }
    }
    void FixedUpdate()
    {
        if (moveDir != 0 && !attacking)
            rb.velocity = new Vector2((moveDir) * runSpeed, rb.velocity.y);

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("particle"))
        {

            if (Red < .75f)
            {
                Red += .01f;
                StopAllCoroutines();
                StartCoroutine(FlashRed());
            }
            else
            {
                PlayerDeath();
                //Debug.LogError(" u ded");
            }
            
        }
    }

    public IEnumerator FlashRed()
    {
        
        float initRed = Red;
        if (initRed > 1)
            initRed = 1;
        
        sprite.color = new Color(1 - initRed/2 , 1 - initRed, 1 - initRed);
        while (initRed > 0)
        {
            sprite.color = new Color(1 - initRed/2, 1 - initRed, 1 - initRed);
            initRed -= .05f;
            yield return new WaitForSeconds(.1f);
            
        }
        
        sprite.color = Color.white;
        Red = 0;


    }

    public void PlayerDeath()
    {
        GameObject deathOBJ = Instantiate(deathObj, transform.position, transform.rotation);
        
        Balloon tBalloon = FindObjectOfType<Balloon>();
        if (tBalloon == null)
        {
            tBalloon = Instantiate(balloon, (_levelManager._mainCamera.transform.position + new Vector3(-20, 11,10)), balloon.gameObject.transform.rotation).GetComponent<Balloon>();
        }
        else
        {
            tBalloon.transform.position = _levelManager._mainCamera.transform.position + new Vector3(-20, 11,10);
        }

        tBalloon.speed = 3;
        tBalloon._player = deathOBJ.transform;
        tBalloon.death = true;


        //find ballon, if no ballon make ballon;
        //move ballon to near player
        //activate death object
        gameObject.SetActive(false);


    }
}
