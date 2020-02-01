using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MouseLook : MonoBehaviour
{
    public enum Axes { MouseXandY, MouseX, MouseY}
    public Axes Axis = Axes.MouseXandY;

    public float sensitivityX = 10f;
    public float sensitivityY = 10f;

    public float minimumxX = -360f;
    public float maximumX = 360f;

    public float minimumY = -360f;
    public float maximumY = 360f;

    public float rotationX = 0.0f;
    public float rotationY = 0.0f;
    public float lookspeed = 2.0f;


    void FixedUpdate()
    {
        if(Axis == Axes.MouseXandY)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

            Adjust360Clamp();
            transform.localRotation *= Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
            
        }
        else if (Axis == Axes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            Adjust360Clamp();
            transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            Adjust360Clamp();
            transform.localRotation = Quaternion.AngleAxis(rotationY, Vector3.left);
        }
    }

    //Make  functin that prevents the rotation angle to go beyond 360 degrees and clamp it to the minimum and maximum value set in the inspector
    //Testing this might be tricky since the inspector doesnt show float values properly but with the debug function we can
    void Adjust360Clamp()
    {
        //if statement to control the X axis
        if (rotationX < -360)
        {
            rotationX += 360;
        }
        else if (rotationX > 360)
        {
            rotationX -= 360;
        }

        //if statement for the Y axis
        if (rotationY < -360)
        {
            rotationY += 360;
        }
        else if (rotationY > 360)
        {
            rotationY -= 360;
        }

        //Clamp the angles to the min and max set in the inspector
        rotationX = Mathf.Clamp(rotationX, minimumxX, maximumX);
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
