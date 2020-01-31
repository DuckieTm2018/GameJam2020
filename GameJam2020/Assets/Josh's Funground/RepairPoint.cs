using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPoint : MonoBehaviour
{
    public GameObject partRequired;
    private Pickups pickups;

    void Start()
    {
        pickups = partRequired.GetComponent<Pickups>();
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
