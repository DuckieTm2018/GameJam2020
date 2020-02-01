using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectInteractables : MonoBehaviour
{
    public Camera playerCamera;
    public Canvas uiCanvas;
    public Text uiText;
    public TeleportScript tpScript;
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition) ;

        if (Physics.Raycast(ray, out hit, 2))
        {
            Transform objectHit = hit.transform;

            if (hit.collider.gameObject.name == "Teleporter 1" || hit.collider.gameObject.name == "Teleporter 2")
            {
                uiText.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    tpScript.TeleportPlayer();
                }
            }
            else
            {
                uiText.enabled = false;
            }
        }
        else
        {
            uiText.enabled = false;
        }
    }
}
