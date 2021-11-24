using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float runSpeed;
    public float jumpStrength;
    Rigidbody2D rb;
    private Animator am;
    public Transform groundDetect;
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundDetect.position, -Vector2.up, .25f);

        if (hit.collider != null)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
        //if you presss right arrow, run to the right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(runSpeed, 0, 0);
            am.SetBool("walking", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //if ypu press left arrow, run left
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-runSpeed, 0, 0);
            am.SetBool("walking", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            am.SetBool("walking", false);
        }

        //if you press space, jump
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = transform.up * jumpStrength;
        }
        
        


    }
}
