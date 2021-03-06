using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float walkSpeed;
    
    public Animator anim; //anim is the name of the variable that we use to reference the hero's animator
    private bool walkingLeft = false;
    private bool walkingRight = true;
    public bool facingRight = true;
    private Rigidbody2D rb;
    private float moveDir;
    
    public ParticleSystem ps;
    public bool ps_on = false;

    public GameObject mouthLights;

    public bool Attacking;

    public Transform groundDetect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
        anim.SetBool("Walk", true);
        if (Attacking)
        {
            anim.SetTrigger("AttackT");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundDetect.position, -Vector2.up, .25f);
        RaycastHit2D hitforward = Physics2D.Raycast(groundDetect.position, Vector2.right, .25f);

        
        //LEFT
        //start walking left
        if (walkingRight && (hit.collider == null || hitforward.collider != null))
        {
            
            walkingRight = false;
            walkingLeft = true;
            anim.SetBool("Walk", true);
            if(facingRight == true)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                groundDetect.localPosition = new Vector3(-groundDetect.localPosition.x, groundDetect.localPosition.y, groundDetect.localPosition.z);
                ps.transform.localPosition = new Vector3(.2f, .9f, 0);
                facingRight = false;
            }
            //Debug.LogError("im triggered");

            //Set your anim variable here

        }

        //stop walking left
        /*if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            walkingLeft = false;
            anim.SetBool("Walk", false);


            //Set your anim variable here

        }*/

        

        //RIGHT
        //start walking right
        else if (walkingLeft && (hit.collider == null || hitforward.collider != null))
        {
            walkingRight = true;
            
            walkingLeft = false;
            anim.SetBool("Walk", true);

            if (facingRight == false)
            {
                //Debug.Log("i ran");
                GetComponent<SpriteRenderer>().flipX = false;
                groundDetect.localPosition = new Vector3(-groundDetect.localPosition.x, groundDetect.localPosition.y, groundDetect.localPosition.z);
                ps.transform.localPosition = new Vector3(-.2f, .9f, 0);
                facingRight = true;

            }

            //Set your anim variable here

        }

        //stop walking right
        /*if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            walkingRight = false;
            anim.SetBool("Walk", false);


            //Set your anim variable here

        }*/
        if (walkingLeft == true && !Attacking)
        {
            //Debug.Log("please run me");
            moveDir = -1;
        }

        if (walkingRight == true && !Attacking)
        {
            //Debug.Log("im going right");
            moveDir = 1;
        }

        
        //attack
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     anim.SetTrigger("AttackT");
        //     anim.SetBool("Attack", true);
        //     
        //     //Set your anim variable here
        //
        // }
        //
        // if (Input.GetKeyUp(KeyCode.Space))
        // {
        //
        //     anim.SetBool("Attack", false);
        //     //Set your anim variable here
        //
        // }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") ||
            anim.GetCurrentAnimatorStateInfo(0).IsName("AttackR"))
        {
            Attacking = true;
        }
        else
        {
            Attacking = false;
        }

       
        

    }
    void FixedUpdate()
    {
        if (!Attacking)
        {
            if (moveDir != 0)
                rb.velocity = new Vector2((moveDir) * walkSpeed, rb.velocity.y);
        }
        

    }

    public void ps_Toggle()
    {
        if (ps_on)
        {
            ps.Stop();
            mouthLights.SetActive(false);
        }
        else
        {
            ps.Play();
            mouthLights.SetActive(true);

        }

        ps_on = !ps_on;


    }

    public void AttackToggle()
    {
        anim.SetTrigger("AttackT");

    }

    
}
