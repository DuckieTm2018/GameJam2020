using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CircuitFix : MonoBehaviour, IInteract
{
    public GameObject[] sparks;
    public bool used;
    private Animation anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        sparks = GameObject.FindGameObjectsWithTag("Sparking");
        used = false;
    }

    public bool CanInteract()
    {
        return true;
    }

    public void Use()
    {
        if (used == false)
        {
            used = true;
            anim.Play("ANIM_circuitBox");
            foreach (GameObject Sparking in sparks)
            {
                Sparking.gameObject.SetActive(false);
            }
        }
    }
}
