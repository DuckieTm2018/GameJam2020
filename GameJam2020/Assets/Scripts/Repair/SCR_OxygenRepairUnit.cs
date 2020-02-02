using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_OxygenRepairUnit : BaseRepairUnit
{
    public float addedTimeOnRepair;

    public override bool CanInteract()
    {
        return !base.repaired;
    }

    public override void Use()
    {
        Debug.Log("Repaired oxygen console.");
        if (!base.repaired) 
        {
            base.repairRoom.countDown += addedTimeOnRepair;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Don't call base.Start(), this console doesn't need to be repaired to stop the room count down.
        base.repairRoom = room.GetComponent<SCR_RepairRoom>();
        base.requiresParts = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
