using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Power : MonoBehaviour, IInteract
{
    public GameObject lights;
    
    public bool CanInteract()
    {
        return true;
    }

    public void Use()
    {
        if (lights.activeInHierarchy == false)
        {
            lights.SetActive(true);
        }
        else
        {
            lights.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        lights.SetActive(false);   
    }

   
}
