using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class SCR_RepairRoom : MonoBehaviour
{
    public string RoomName;
    public List<KeyValuePair<int, bool>> repairPoints = new List<KeyValuePair<int, bool>>();
    public float countDownSeconds;
    public bool isRoomRepaired;
    public bool startRoom;
    private static Timer countDown;
    public GameObject nextRoom;
    private SCR_RepairRoom nextRepairRoom;

    void Start()
    {
        if(nextRoom != null)
            nextRepairRoom = nextRoom.GetComponent<SCR_RepairRoom>();
        if (startRoom)
            Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Activate() 
    {
        Debug.Log($"{RoomName}'s timer has started.");
        countDown = new Timer()
        {
            Interval = countDownSeconds * 60,
            Enabled = true
        };
        countDown.Elapsed += TimeRanOut;
    }

    internal void UpdateRepairPoint(int id)
    {
        Debug.Log($"Point {id} for {RoomName} has been repaired.");
        repairPoints.RemoveAll(r => r.Key == id);
        repairPoints.Add(new KeyValuePair<int, bool>(id, true));

        if(repairPoints.FindAll(r => r.Value).Count == repairPoints.Count) 
        {
            Debug.Log($"Room {RoomName} has been repaired.");

            countDown.Enabled = false;
            isRoomRepaired = true;
            if (nextRepairRoom == null) 
            {
                Console.WriteLine($"Last room has been repaired.");

                // finished the game!
            }
            else
                nextRepairRoom.Activate();
        }
    }

    private void TimeRanOut(object sender, ElapsedEventArgs e)
    {
        throw new NotImplementedException();
    }
}
