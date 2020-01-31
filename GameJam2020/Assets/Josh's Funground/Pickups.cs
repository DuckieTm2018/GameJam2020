using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject hands;
    public bool held;
    public Rigidbody rb;
    public float throwingPower = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseOver()
    {
        if (held == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.transform.parent = hands.transform;
                held = true;
                rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            }
        }
    }

    void Update()
    {
        if (held == true)
        {
            transform.localPosition = new Vector3(0f, 0f, 0f);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                held = false;
                rb.constraints = RigidbodyConstraints.None;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                held = false;
                rb.constraints = RigidbodyConstraints.None;
                rb.AddForce(hands.transform.forward * throwingPower);
            }
        }
    }
}
