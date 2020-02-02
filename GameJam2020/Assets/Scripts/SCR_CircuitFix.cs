using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CircuitFix : MonoBehaviour, IInteract
{
    public GameObject[] sparks;

    void Start()
    {
        sparks = GameObject.FindGameObjectsWithTag("Sparking");
    }

    public bool CanInteract()
    {
        return true;
    }

    public void Use()
    {
        foreach (GameObject Sparking in sparks)
        {
            Sparking.gameObject.SetActive(false);
        }
    }
}
