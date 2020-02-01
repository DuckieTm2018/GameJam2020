using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CharacterController : MonoBehaviour
{
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




    void Awake()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().useGravity = false;

  
        capsule = GetComponent<CapsuleCollider>();
        sphere = GetComponent<SphereCollider>();
        distance = capsule.height / 2; //calculate the distance to the ground
        
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;
            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (canJump && Input.GetButton("Jump"))
            {
                GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runSpeed;
                sphere.enabled = false;
                capsule.enabled = true;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                speed = crouchSpeed;
                //capsule.height = 0.5f;
                //capsule.center = new Vector3(capsule.center.x, 0.25f, capsule.center.z);

                sphere.enabled = true;
                capsule.enabled = false;
            }
            else
            {
                speed = walkSpeed;
                sphere.enabled = false;
                capsule.enabled = true;
            }
        }
        // We apply gravity manually for more turning control
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));
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
