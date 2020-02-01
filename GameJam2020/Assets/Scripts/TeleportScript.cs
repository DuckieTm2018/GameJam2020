using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour, IInteract
{
    public GameObject player;
    public GameObject otherTeleport;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Use()
    {
        Debug.Log("Teleport!");
        player.transform.position = otherTeleport.transform.position + otherTeleport.transform.TransformDirection(new Vector3(0, -0, -1f));
    }
}
