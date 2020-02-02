using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_LadderClimb: MonoBehaviour
{
    public GameObject playerOBJ;
    public bool canClimb = false;
    public float speed = 1f;
    public Animator anim;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            canClimb = true;
            playerOBJ = col.gameObject;
        }
    }

    void OnCollisionExit(Collision col2)
    {
        if(col2.gameObject.tag == "Player")
        {
            canClimb = false;
            playerOBJ = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canClimb)
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerOBJ.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
                anim.SetBool("isClimbing", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerOBJ.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
                anim.SetBool("isClimbing", true);
            }
            anim.SetBool("isClimbing", false);
        }
    }
}
