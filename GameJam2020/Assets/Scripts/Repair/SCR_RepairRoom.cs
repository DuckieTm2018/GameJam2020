using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.SceneManagement;

public class SCR_RepairRoom : MonoBehaviour
{
    public string RoomName;
    public List<KeyValuePair<int, bool>> repairUnits = new List<KeyValuePair<int, bool>>();
    public float countDownSeconds;
    public bool isRoomRepaired;
    public bool startRoom;
  
    public GameObject nextRoom;
    private SCR_RepairRoom nextRepairRoom;
    private bool active;
    public float countDown;


    void Start()
    {
        if(nextRoom != null)
            nextRepairRoom = nextRoom.GetComponent<SCR_RepairRoom>();
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
        countDown = countDownSeconds;
        active = true;
    }

    internal void UpdateRepairUnits(int id)
    {
        Debug.Log($"Point {id} for {RoomName} has been repaired.");
        repairUnits.RemoveAll(r => r.Key == id);
        repairUnits.Add(new KeyValuePair<int, bool>(id, true));

        if(repairUnits.FindAll(r => r.Value).Count == repairUnits.Count) 
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
        Screen.lockCursor = false;
        SceneManager.LoadScene("GameOverMenu");
    }
}
