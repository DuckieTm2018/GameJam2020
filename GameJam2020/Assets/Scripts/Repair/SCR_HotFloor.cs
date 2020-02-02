using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_HotFloor : MonoBehaviour
{
    public GameObject coolingSystem;
    public GameObject player;
    public Material cooledMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coolingSystem.GetComponent<SCR_CoolingSystem>().repaired == false && player.GetComponent<DetectSurface>().onHotSurface == true)
        {
            player.GetComponent<SCR_CharacterController>().speed = (player.GetComponent<SCR_CharacterController>().speed / 5);
        }

        if (coolingSystem.GetComponent<SCR_CoolingSystem>().repaired == true)
        {
            this.GetComponent<MeshRenderer>().material = cooledMaterial;
        }
    }
}
