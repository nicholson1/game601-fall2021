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

	public float MountedRunSpeed;
	public float MountedWalkSpeed;


	public GameObject groundCheckHitSphere;
	public GameObject groundCheckNoHitSphere;

	
	private bool jumping;
	private Animator am;
	private Rigidbody rb;
	Vector3 smoothMoveVelocity;
	public Vector3 moveAmount;
	private Vector3 rotateAmount;
	
	private bool Mounted;
	private Vector3 lastPosition;

    void Start()
    {
        am = GetComponentInChildren<Animator>();
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
	    bool hit = Physics.Raycast(transform.position + new Vector3(0,.1f,0), Vector3.down, 10);

	    if (hit)
	    {
		    this.lastPosition = transform.position;
	    }
	    else
	    {
		    //Debug.Log("we fell through" + gameObject.name);
		    transform.position = new Vector3(transform.position.x, lastPosition.y +.05f , transform.position.z);
	    }
	    
	    
    }
	   

    void Move()
    {
	    if (grounded)
	    {
		    Vector3 moveDir = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));

		    if (moveDir.z > 0)
		    {
			    if (moveDir.z > .5f)
			    {
				    moveAmount = Vector3.SmoothDamp(moveAmount,
					    moveDir * (Input.GetButton("Sprint") ? sprintSpeed : sprintSpeed), ref smoothMoveVelocity,
					    smoothTime);
			    }else
			    {
				    moveAmount = Vector3.SmoothDamp(moveAmount,
					    moveDir * (Input.GetButton("Sprint") ? sprintSpeed : walkSpeed), ref smoothMoveVelocity,
					    smoothTime);
			    }
			    
		    }
		    else
		    {
			    moveAmount = Vector3.SmoothDamp(moveAmount,
				    moveDir * (Input.GetButton("Sprint") ? walkSpeed : walkSpeed), ref smoothMoveVelocity,
				    smoothTime);
		    }

		    
	    }

	    if (!Mounted)
	    {
		    am.SetFloat("movement", moveAmount.z);

	    }
	    else
	    {
		    
		    //if moving is non zero
		    // just walk
		    if (moveAmount.z > 1)
		    {
			    am.SetFloat("movement", 1);
		    }
		    else
		    {
			    am.SetFloat("movement", 0);

		    }

	    }
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
	    if(Input.GetButtonDown("Jump") && grounded )
	    {
		    am.SetBool("jumping", true);
		    
			    //mount
			    if(Mounted)
					MountToggle();
		    
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

    public void Test()
    {
	    Debug.Log("TestWworking");
    }

    public void MountToggle()
    {
	    
	    if (!Mounted)
	    {
		    walkSpeed += MountedWalkSpeed;
		    sprintSpeed += MountedRunSpeed;
		    //GetComponent<CapsuleCollider>().
		    //rb.constraints = RigidbodyConstraints.FreezeAll;

	    }
	    else
	    {
		    walkSpeed -= MountedWalkSpeed;
		    sprintSpeed -= MountedRunSpeed;
		    GetComponentInChildren<Mount>().DisMount();
		    //GetComponent<CapsuleCollider>().enabled = true;

		    

	    }

	    Mounted = !Mounted;

    }

    /*public void OnControllerColliderHit(ControllerColliderHit hit)
    {
	    if (rb.velocity.z < 1)
	    {
		    am.SetTrigger("landing");

	    }
    }*/

    
    
}

