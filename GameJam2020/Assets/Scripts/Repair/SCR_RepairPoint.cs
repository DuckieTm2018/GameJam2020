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
    public GameObject fixedObject;
    public GameObject brokenObject;

    private bool repaired;

    void Start()
    {
        pickup = partRequired.GetComponent<SCR_Pickups>();
        repairUnit = unit.GetComponent<BaseRepairUnit>();
        brokenObject.SetActive(false);

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

        fixedObject.SetActive(true);
        brokenObject.SetActive(false);

        repaired = true;
        repairUnit.UpdateRepairPoints(Id);
    }

    public bool CanInteract()
    {
        return pickup.held == true && !repaired;
    }
}
