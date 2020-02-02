using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSurface : MonoBehaviour
{
    public bool onHotSurface = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.gameObject.name == "SpicyFloor")
            {
                onHotSurface = true;
            }
            else
            {
                onHotSurface = false;
            }
        }
    }
}
