using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_RepairPoint : MonoBehaviour
{
    public int Id;
    public GameObject room;
    public GameObject partRequired;
    private SCR_Pickups pickups;
    private SCR_RepairRoom repairRoom;

    void Start()
    {
        pickups = partRequired.GetComponent<SCR_Pickups>();
        repairRoom = room.GetComponent<SCR_RepairRoom>();
        repairRoom.repairPoints.Add(new KeyValuePair<int, bool>(this.Id, false));
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
                repairRoom.UpdateRepairPoint(Id);
            }
        }
    }
}
