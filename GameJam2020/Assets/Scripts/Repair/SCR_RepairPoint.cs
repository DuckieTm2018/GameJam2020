using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_RepairPoint : MonoBehaviour, IInteract
{
    public GameObject unit;
    public GameObject partRequired;
    public int Id;
    private SCR_Pickups pickup;
    private BaseRepairUnit repairUnit;

    private bool repaired;

    void Start()
    {
        pickup = partRequired.GetComponent<SCR_Pickups>();
        repairUnit = unit.GetComponent<BaseRepairUnit>();

        Id = repairUnit.repairPoints.Count + 1;
        repairUnit.repairPoints.Add(new KeyValuePair<int, bool>(this.Id, false));
    }

    public void Use()
    {
        Debug.Log("Repaired the repair point.");

        pickup.held = false;
        pickup.handContainer.InUse = false;

        partRequired.transform.parent = null;
        partRequired.SetActive(false);

        repaired = true;
        repairUnit.UpdateRepairPoint(Id);
    }

    public bool CanInteract()
    {
        return pickup.held == true && !repaired;
    }
}
