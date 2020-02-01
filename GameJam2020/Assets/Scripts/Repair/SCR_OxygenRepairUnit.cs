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
            base.Repaired();
            base.repairRoom.countDown += addedTimeOnRepair;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        base.requiresParts = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
