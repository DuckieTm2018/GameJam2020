using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CoolingSystem : BaseRepairUnit
{
    public override bool CanInteract()
    {
        return false;
    }

    public override void Use()
    {

    }

    void Start()
    {
        base.Start();
        base.requiresParts = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
