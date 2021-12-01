/*
INCLUDES:
	Movement with WSAD and Arrows
    Turning head and body
*/

using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;

    [FormerlySerializedAs("speed")] public float runSpeed = 6.0f;
    public float walkspeed = 3.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
	public float turnSensitivity = 4;
	public Transform head;


	
	private bool jumping;
	private Animator am;
	private Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;
	private Vector3 curEuler = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        am = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
	    if (characterController.isGrounded)
	    {
		    // We are grounded, so recalculate
		    // move direction directly from axes

		    moveDirection =
			    transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")));
		    moveDirection *= runSpeed;


		    if (Input.GetButton("Jump"))
		    {
			    am.SetTrigger("jumping");
			    moveDirection.y = jumpSpeed;
			    //rb.AddForce(transform.up * jumpSpeed);
		    }
		    if (moveDirection.magnitude >= runSpeed - .05f)
		    {
			    am.SetBool("running", true);
			    am.SetBool("walking", false);
		    }
		    else if (moveDirection.magnitude >= 1){
			    am.SetBool("running", false);
			    am.SetBool("walking", true);
		    
		    }
		    else
		    {
			    am.SetBool("running", false);
			    am.SetBool("walking", false);
		    }
	    }
	    /*if (rb.velocity.z < 0)
	    {
		    am.SetTrigger("falling");
	    }*/

	   

	    //rotate head on x-axis (Up and down)
	    float XturnAmount = Input.GetAxis("Mouse Y") * Time.deltaTime * turnSensitivity;
	    curEuler = Vector3.right * Mathf.Clamp(curEuler.x - XturnAmount, -90f, 90f);
	    head.localRotation = Quaternion.Euler(curEuler);

	    //rotate body on y-axis (Sideways)
	    float YturnAmount = Input.GetAxis("Mouse X") * Time.deltaTime * turnSensitivity;
	    transform.Rotate(Vector3.up * YturnAmount);

	    // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
	    // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
	    // as an acceleration (ms^-2)
	    moveDirection.y -= gravity * Time.deltaTime;

	    // Move the controller
	    characterController.Move(moveDirection * Time.deltaTime);

	   


}

    /*public void OnControllerColliderHit(ControllerColliderHit hit)
    {
	    if (rb.velocity.z < 1)
	    {
		    am.SetTrigger("landing");

	    }
    }*/

    
    
}

