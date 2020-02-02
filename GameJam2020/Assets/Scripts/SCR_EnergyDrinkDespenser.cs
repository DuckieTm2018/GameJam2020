using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnergyDrinkDespenser : MonoBehaviour, IInteract
{
    GameObject playerObject;
    SCR_CharacterController characterController;
    public float playerSpeedIncrease;
    public float activeEffectTime;
    public bool timerActive;
    public Animation anim;
    private float timer;

    public bool CanInteract()
    {
        return true;
    }

    public void Use()
    {
        anim.Play();
        timer = activeEffectTime;

        if (!timerActive)
        {
            ChangePlayerSpeed(false);
            timerActive = true;
        }
    }

    private void ChangePlayerSpeed(bool reset)
    {
        if (reset)
        {
            characterController.crouchSpeed -= playerSpeedIncrease;
            characterController.speed -= playerSpeedIncrease;
            characterController.runSpeed -= playerSpeedIncrease;
            characterController.walkSpeed -= playerSpeedIncrease;
        }
        else 
        {
            characterController.crouchSpeed += playerSpeedIncrease;
            characterController.speed += playerSpeedIncrease;
            characterController.runSpeed += playerSpeedIncrease;
            characterController.walkSpeed += playerSpeedIncrease;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        characterController = playerObject.GetComponent<SCR_CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timerActive = false;
                ChangePlayerSpeed(true);
            }
        }
    }
}
