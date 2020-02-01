using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRepairUnit : MonoBehaviour
{
    int Id;
    public GameObject room;
    private SCR_RepairRoom repairRoom;
    public List<KeyValuePair<int, bool>> repairPoints = new List<KeyValuePair<int, bool>>();

    // Start is called before the first frame update
    void Start()
    {
        repairRoom = room.GetComponent<SCR_RepairRoom>();
        Id = repairRoom.repairUnits.Count + 1;
        repairRoom.repairUnits.Add(new KeyValuePair<int, bool>(this.Id, false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void UpdateRepairPoint(int id)
    {
        Debug.Log($"Point {id} for {Id} has been repaired.");
        repairPoints.RemoveAll(r => r.Key == id);
        repairPoints.Add(new KeyValuePair<int, bool>(id, true));

        if (repairPoints.FindAll(r => r.Value).Count == repairPoints.Count)
        {
            repairRoom.UpdateRepairUnits(Id);
            Repaired();
        }
    }

    internal abstract void Repaired();
}
