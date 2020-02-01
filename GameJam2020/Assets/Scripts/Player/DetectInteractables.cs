using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectInteractables : MonoBehaviour
{
    public Camera playerCamera;
    public Canvas uiCanvas;
    public Text uiText;
    public RaycastHit hit;
    public float raycastLength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition) ;

        var hits = Physics.RaycastAll(ray, raycastLength);

        uiText.enabled = false;

        foreach (var hit in hits) 
        { 
            Transform objectHit = hit.transform;
            IInteract interactable = hit.collider.gameObject.GetComponent<IInteract>();

            if (interactable != null && interactable.CanInteract())
            {
                uiText.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("can interact with object.");
                    interactable.Use();
                }
                break;
            }
        }

        if(hits.Length == 0) 
        { 
            uiText.enabled = false;
        }
    }
}
