using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroScript : MonoBehaviour
{
    public float walkSpeed;
    
    public Animator anim; //anim is the name of the variable that we use to reference the hero's animator
    private bool walkingLeft;
    private bool walkingRight;
    private bool walkingUp;
    private bool walkingDown;
    public bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //LEFT
        //start walking left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            walkingLeft = true;
            anim.SetBool("Side", true);
            if(facingRight == true)
            {
                GetComponent<SpriteRenderer>().flipX = true;Debug.Log("it should have flipped");
            }

            //Set your anim variable here

        }

        //stop walking left
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            walkingLeft = false;
            anim.SetBool("Side", false);


            //Set your anim variable here

        }

        if (walkingLeft == true)
        {
            transform.Translate(-walkSpeed, 0, 0);
        }

        //RIGHT
        //start walking right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            walkingRight = true;
            facingRight = true;
            anim.SetBool("Side", true);

            if (facingRight == true)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            //Set your anim variable here

        }

        //stop walking right
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            walkingRight = false;
            anim.SetBool("Side", false);


            //Set your anim variable here

        }

        if (walkingRight == true)
        {
            transform.Translate(walkSpeed, 0, 0);
        }

        //UP
        //start walking up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            walkingUp = true;
            anim.SetBool("Up", true);

            //facingRight = false;

            //Set your anim variable here


        }

        //stop walking up
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            walkingUp = false;
            anim.SetBool("Up", false);


            //Set your anim variable here

        }

        if (walkingUp == true)
        {
            transform.Translate(0, walkSpeed, 0);
        }

        //Down
        //start walking down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            walkingDown = true;
            anim.SetBool("Down", true);

            //facingRight = false;

            //Set your anim variable here

        }

        //stop walking down
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            walkingDown = false;
            anim.SetBool("Down", false);


            //Set your anim variable here

        }

        if (walkingDown == true)
        {
            transform.Translate(0, -walkSpeed, 0);
        }

        //attack
        if (Input.GetKeyDown(KeyCode.Space))
        {

            anim.SetTrigger("Attack");
            //Set your anim variable here

        }

        




    }

    
}
