using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public DetectInteractables findTP;
    public GameObject player;
    public GameObject tp1;
    public GameObject tp2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TeleportPlayer()
    {
        if (findTP.hit.collider.gameObject.name == "Teleporter 1")
        {
            Debug.Log("TP 1 activated!");
            player.transform.position = tp2.transform.position + tp2.transform.TransformDirection(new Vector3(0, 0, 1f));
        }
        else if (findTP.hit.collider.gameObject.name == "Teleporter 2")
        {
            Debug.Log("TP 2 activated!");
            player.transform.position = tp1.transform.position + tp1.transform.TransformDirection(new Vector3(0, -0, -1f));
        }
    }


}
