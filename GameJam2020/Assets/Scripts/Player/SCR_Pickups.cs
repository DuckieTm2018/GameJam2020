using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Pickups : MonoBehaviour, IInteract
{
    public GameObject handLocation;
    public SCR_Hands handContainer;

    public bool held;
    public Rigidbody rb;
    public float throwingPower = 5.0f;

    private Vector3 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handLocation = GameObject.FindGameObjectWithTag("PlayerHands");
        handContainer = handLocation.GetComponent<SCR_Hands>();
    }

    public bool CanInteract()
    {
        return !held && !handContainer.InUse;
    }

    public void Use()
    {
        Debug.Log("Pickup part.");

        this.gameObject.transform.parent = handLocation.transform;
        held = true;
        handContainer.InUse = true;

        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        Physics.IgnoreLayerCollision(8, 9, true);
        transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        if (held == true)
        {
            dir = handLocation.transform.position - this.transform.position;
            dir.Normalize();
            rb.velocity = dir;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                held = false;
                handContainer.InUse = true;

                transform.parent = null;
                rb.constraints = RigidbodyConstraints.None;
                Physics.IgnoreLayerCollision(8, 9, false);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                held = false;
                handContainer.InUse = true;

                transform.parent = null;
                rb.constraints = RigidbodyConstraints.None;
                Physics.IgnoreLayerCollision(8, 9, false);
                rb.AddForce(handLocation.transform.forward * throwingPower);
            }
        }
    }
}
