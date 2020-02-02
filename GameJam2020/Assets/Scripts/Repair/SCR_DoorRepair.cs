using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_DoorRepair : BaseRepairUnit
{
    public GameObject door;

    public override bool CanInteract()
    {
        return true;
    }

    public override void Use()
    {
        if (!base.repaired)
        {
            base.Repaired();
            Debug.Log("Door repaired!");
        }
        else
        {
            door.GetComponent<Animator>().enabled = true;
            GameObject doorFrame = door.transform.Find("pCylinder3").gameObject;
            doorFrame.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Door opened!");
        }

    }
}
