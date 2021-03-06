﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GenericRepairUnit : BaseRepairUnit
{
    public override bool CanInteract()
    {
        return !base.repaired;
    }

    public override void Use()
    {
        if (!base.repaired)
        {
            base.Repaired();
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
