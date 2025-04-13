using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public Camera cam;
    public float xRotation = 0f;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    public void ProcessLook(Vector2 input)
    {
        if(pauseMenu.Paused == false)
        {
             float mouseX = input.x * xSensitivity * Time.deltaTime;;
        float mousey = input.y * ySensitivity * Time.deltaTime;; 

        xRotation -= mousey ;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
        }
       
    }
   
}
