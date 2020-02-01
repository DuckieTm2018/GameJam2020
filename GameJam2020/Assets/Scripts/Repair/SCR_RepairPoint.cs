using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_RepairPoint : MonoBehaviour, IInteract
{
    public GameObject room;
    public GameObject partRequired;
    public int Id;
    private SCR_Pickups pickup;
    private SCR_RepairRoom repairRoom;

    private bool repaired;

    void Start()
    {
        pickup = partRequired.GetComponent<SCR_Pickups>();
        repairRoom = room.GetComponent<SCR_RepairRoom>();
        Id = repairRoom.repairPoints.Count + 1;
        repairRoom.repairPoints.Add(new KeyValuePair<int, bool>(this.Id, false));
    }

    public void Use()
    {
        Debug.Log("Repaired the repair point.");

        pickup.held = false;
        pickup.handContainer.InUse = false;

        partRequired.transform.parent = null;
        partRequired.SetActive(false);

        repaired = true;
        repairRoom.UpdateRepairPoint(Id);
    }

    public bool CanInteract()
    {
        return pickup.held == true && !repaired;
    }
}
