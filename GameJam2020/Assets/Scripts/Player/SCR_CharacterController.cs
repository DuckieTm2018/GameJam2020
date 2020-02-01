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
    private Transform tr;
    private CapsuleCollider capsule;



    void Awake()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().useGravity = false;

        tr = transform;
        CapsuleCollider ch = GetComponent<CapsuleCollider>();
        distance = ch.height / 2; //calculate the distance to the ground
        
    }

    void FixedUpdate()
    {
        float vScale = 1.0f;

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
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                speed = crouchSpeed;
                vScale = 0.5f;                
            }
            else
            {
                speed = walkSpeed;
            }
        }
        // We apply gravity manually for more turning control
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));
        grounded = false;

        float ultScale = tr.localScale.y;

        Vector3 tmpScale = tr.localScale;
        Vector3 tmpPosition = tr.position;

        tmpScale.y = Mathf.Lerp(tr.localScale.y, vScale, 5 * Time.deltaTime);
        tr.localScale = tmpScale;

        tmpPosition.y += distance * (tr.localScale.y - ultScale); //fix vertical position
        tr.position = tmpPosition; 

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
