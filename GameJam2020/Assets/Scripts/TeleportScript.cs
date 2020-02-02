using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour, IInteract
{
    public GameObject otherTeleport;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Use()
    {
        player.transform.position = otherTeleport.transform.position + otherTeleport.transform.TransformDirection(new Vector3(-2.5f, 1f, 0f));
    }

    public bool CanInteract()
    {
        return true;
    }
}
