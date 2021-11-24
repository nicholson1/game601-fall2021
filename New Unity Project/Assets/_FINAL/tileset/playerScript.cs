using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float runSpeed;
    public float jumpStrength;
    Rigidbody2D rb;
    private Animator am;
    public Transform groundDetect;
    private bool onGround;
    private float moveDir;
    private float Red = 0;
    private levelManager _levelManager;


    private bool jumping =  false;
    private bool falling = false;

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
            Debug.Log(Mathf.Abs(rb.velocity.y));
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

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            moveDir = Input.GetAxis("Horizontal");
        }
        else
        {
            moveDir = 0;
            am.SetBool("walking", false);
        }
        
        //if you presss right arrow, run to the right
        if (moveDir > 0)
        {
            am.SetBool("walking", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //if ypu press left arrow, run left
        else if (moveDir <0)
        {
            am.SetBool("walking", true);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            am.SetBool("jumping", true);
            if (falling && onGround)
            {
                _levelManager.JumpTrigger();
                rb.AddForce(transform.up * jumpStrength, ForceMode2D.Impulse);


            }
        }
        
       
    }

    public void Jump()
    {
        if (onGround)
        {
            _levelManager.JumpTrigger();
            rb.AddForce(transform.up * jumpStrength, ForceMode2D.Impulse);
            jumping = true;

        }
    }
    void FixedUpdate()
    {
        if (moveDir != 0)
            rb.velocity = new Vector2((moveDir) * runSpeed, rb.velocity.y);

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("particle"))
        {
            
            if (Red < 1.25)
            {
                Red += .01f;
                StopAllCoroutines();
                StartCoroutine(FlashRed());
            }
            else
            {
                Debug.LogError(" u ded");
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
}
