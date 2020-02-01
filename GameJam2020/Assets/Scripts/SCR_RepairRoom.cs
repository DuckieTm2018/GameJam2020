using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.SceneManagement;

public class SCR_RepairRoom : MonoBehaviour
{
    public string RoomName;
    public List<KeyValuePair<int, bool>> repairPoints = new List<KeyValuePair<int, bool>>();
    public float countDownSeconds;
    public bool isRoomRepaired;
    public bool startRoom;
  
    public GameObject nextRoom;
    private SCR_RepairRoom nextRepairRoom;
    private bool active;
    private float countDown;


    void Start()
    {
        if(nextRoom != null)
            nextRepairRoom = nextRoom.GetComponent<SCR_RepairRoom>();

        if (startRoom && !active)
            Activate();

        var count = countDownSeconds * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (active) 
        {
            if (countDown <= 0.0f) 
            {
                active = false;
                TimeRanOut();
            }
            else if (countDown > 0.0f)
            {
                countDown -= Time.deltaTime;
            }
        }
    }

    internal void Activate() 
    {
        Debug.Log($"{RoomName}'s timer has started.");
        active = true;
    }

    internal void UpdateRepairPoint(int id)
    {
        Debug.Log($"Point {id} for {RoomName} has been repaired.");
        repairPoints.RemoveAll(r => r.Key == id);
        repairPoints.Add(new KeyValuePair<int, bool>(id, true));

        if(repairPoints.FindAll(r => r.Value).Count == repairPoints.Count) 
        {
            Debug.Log($"Room {RoomName} has been repaired.");

            active = false;
            isRoomRepaired = true;
            if (nextRepairRoom == null) 
            {
                Debug.Log($"Last room has been repaired.");

                // finished the game!
            }
            else
                nextRepairRoom.Activate();
        }
    }

    public void TimeRanOut() 
    {
        Debug.Log($"Time Ran out.");
        SceneManager.LoadScene(1);
    }
}
