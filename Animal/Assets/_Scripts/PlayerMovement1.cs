/*
INCLUDES:
	Movement with WSAD and Arrows
    Turning head and body
*/

using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;


public class PlayerMovement1 : MonoBehaviour
{
    

    public float sprintSpeed = 6.0f;
    public float walkSpeed = 3.0f;
    public float jumpForce = 125f;
    public float rotationSpeed = 1;
	public bool grounded;
	public float smoothTime = 0.15f;

	public GameObject groundCheckHitSphere;
	public GameObject groundCheckNoHitSphere;

	
	private bool jumping;
	private Animator am;
	private Rigidbody rb;
	Vector3 smoothMoveVelocity;
	Vector3 moveAmount;
	private Vector3 rotateAmount;

    void Start()
    {
        am = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    /*private void OnCollisionEnter(Collision other)
    {
	    if (other.gameObject.CompareTag("Ground"))
	    {
		    grounded = true;
		    am.SetBool("falling", false);
	    }
	    
    }

    private void OnCollisionExit(Collision other)
    {
	    if(other.gameObject.CompareTag("Ground"))
		    grounded = false;
    }*/

    private void Update()
    {
	    //Debug.Log(grounded);
	    //Vector3 fwd = transform.TransformDirection(Vector3.forward);

	    RaycastHit hit;

	    Vector3 p1 = transform.position;
	    float distanceToObstacle = 0;
	    //bool objectHit = false;

	    // Cast a sphere wrapping character controller 10 meters forward
	    // to see if it is about to hit anything.
	    if (Physics.SphereCast(p1, .3f, Vector3.down, out hit, 1))
	    {
		    distanceToObstacle = hit.distance;
		    if (hit.collider.CompareTag("Animal"))
		    {
			    //hit.collider.transform.parent.SetParent(transform);
		    }
		    /*groundCheckHitSphere.SetActive(true);
		    groundCheckNoHitSphere.SetActive(false);
		    groundCheckHitSphere.transform.position =  transform.position + new Vector3(0, - hit.distance, 0);
		    */
		    
		    //objectHit = hit.collider.CompareTag("Ground");

	    }
	    /*else
	    {
		    groundCheckHitSphere.SetActive(false);
		    groundCheckNoHitSphere.SetActive(true);
		    groundCheckNoHitSphere.transform.position = transform.position + new Vector3(0,-1,0);
	    }*/
	    //if(objectHit)
		//Debug.Log(distanceToObstacle);
	    if(distanceToObstacle < 1f)
	    {
		    grounded = true;
		    am.SetBool("landing", true);
		    am.SetBool("falling", false);
		    am.SetBool("jumping", false);
	    }
	    else
	    {
		    grounded = false;
	    }

	    Move();
	    Jump();
	    Rotate();

	    //Debug.Log(rb.velocity.y);
	    if (rb.velocity.y < -.01f)
	    {
		    am.SetBool("falling", true);
		    am.SetBool("landing", false);

	    }
    }

    void FixedUpdate()
    {
	    
	    rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);

	    if (rotateAmount != Vector3.zero)
	    {
		    Quaternion deltaRotation = Quaternion.Euler(rotateAmount * Time.fixedDeltaTime * rotationSpeed);
		    rb.MoveRotation(rb.rotation * deltaRotation);
		    if (moveAmount.z < .1 && moveAmount.z > -.1)
		    {
			    am.SetFloat("turn", rotateAmount.y);
                
		    }
	    }
	    else
	    {
		    am.SetFloat("turn", 0);

	    }
	    
	    
    }
	   

    void Move()
    {
	    if (grounded)
	    {
		    Vector3 moveDir = new Vector3(0, 0, Input.GetAxisRaw("Vertical")).normalized;

		    if (moveDir.z > 0)
		    {
			    moveAmount = Vector3.SmoothDamp(moveAmount,
				    moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity,
				    smoothTime);
		    }
		    else
		    {
			    moveAmount = Vector3.SmoothDamp(moveAmount,
				    moveDir * (Input.GetKey(KeyCode.LeftShift) ? walkSpeed : walkSpeed), ref smoothMoveVelocity,
				    smoothTime);
		    }

		    
	    }

	    am.SetFloat("movement", moveAmount.z);
	    //Debug.Log(moveAmount.z);
	    /*if (moveAmount.z > walkSpeed + 1)
	    {
		    am.SetBool("running", true);
		    am.SetBool("walking", false);
		    am.SetBool("walkingBack", false);

	    }
	    else if (moveAmount.z > .1f)
	    {
		    am.SetBool("walking", true);
		    am.SetBool("running", false);
		    am.SetBool("walkingBack", false);
		    
	    }
	    else if (moveAmount.z <= -.1f)
	    {
		    am.SetBool("walkingBack", true);
		    am.SetBool("walking", false);
		    am.SetBool("running", false);

	    }
	    else if (moveAmount.z < .1f)
	    {
		    am.SetBool("walkingBack", false);
		    am.SetBool("walking", false);
		    am.SetBool("running", false);
	    }*/
    }

    void Rotate()
    {
	    
	    rotateAmount = new Vector3(0, Input.GetAxisRaw("Horizontal"), 0).normalized;
	    //Debug.Log(rotateAmount.magnitude);
    }

    void Jump()
    {
	    if(Input.GetKeyDown(KeyCode.Space) && grounded)
	    {
		    am.SetBool("jumping", true);
		    
		    

	    }
    }

    public void JumpRB()
    {
	    if (grounded)
	    {
		    rb.AddForce(transform.up * jumpForce);
		    am.SetBool("jumping", false);
		    grounded = false;


	    }
    }

    /*public void OnControllerColliderHit(ControllerColliderHit hit)
    {
	    if (rb.velocity.z < 1)
	    {
		    am.SetTrigger("landing");

	    }
    }*/

    
    
}

