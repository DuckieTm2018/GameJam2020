using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CharacterController : MonoBehaviour
{
    public Animator anim;

    public float runSpeed = 10.0f;
    public float walkSpeed = 5.0f;
    public float crouchSpeed = 2.0f;
    public float speed;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;

    private float height;
    private float distance; //distance to ground
    public CapsuleCollider capsule;
    public SphereCollider sphere;
    public Rigidbody rigidbody;
    public float currentVelocity;


    void Awake()
    {

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.useGravity = false;

  
        capsule = GetComponent<CapsuleCollider>();
        sphere = GetComponent<SphereCollider>();
        distance = capsule.height / 2; //calculate the distance to the ground
        
    }

    void Update()
    {
        currentVelocity = (rigidbody.velocity.x + rigidbody.velocity.z);
        currentVelocity = Mathf.Abs(currentVelocity);

        if (grounded)
        {
            anim.SetFloat("Speed", currentVelocity);

            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;
            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rigidbody.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (canJump && Input.GetButton("Jump"))
            {
                anim.SetTrigger("Jump");
                rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }

            if (Input.GetKey(KeyCode.LeftShift) && targetVelocity.x > 0 && targetVelocity.z > 0)
            {
                speed = runSpeed;
                anim.SetBool("isRunning", true);
                sphere.enabled = false;
                capsule.enabled = true;
            }
            else
            {
                speed = walkSpeed;
                sphere.enabled = false;
                capsule.enabled = true;
                anim.SetBool("isRunning", false);
            }


            if (Input.GetKey(KeyCode.LeftControl))
            {
                speed = crouchSpeed;
                //capsule.height = 0.5f;
                //capsule.center = new Vector3(capsule.center.x, 0.25f, capsule.center.z);

                sphere.enabled = true;
                capsule.enabled = false;

                anim.SetBool("Crouch_Walk", true);
            }
            else
            {
                speed = walkSpeed;
                sphere.enabled = false;
                capsule.enabled = true;
                anim.SetBool("Crouch_Walk", false);
            }
        }
        // We apply gravity manually for more turning control
        rigidbody.AddForce(new Vector3(0, -gravity * rigidbody.mass, 0));
        grounded = false;

    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}
