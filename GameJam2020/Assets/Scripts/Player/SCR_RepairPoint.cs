using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_RepairPoint : MonoBehaviour
{
    public GameObject partRequired;
    private SCR_Pickups pickups;

    void Start()
    {
        pickups = partRequired.GetComponent<SCR_Pickups>();
    }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pickups.held == true)
            {
                pickups.held = false;
                partRequired.transform.parent = null;
                partRequired.SetActive(false);
            }
        }
    }
}
