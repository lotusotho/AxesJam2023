using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehaviour : MonoBehaviour
{
    // Límite izquierdo de la pantalla
    public float minX;
    // Límite derecho de la pantalla
    public float maxX; 
    // Límite inferior de la pantalla
    public float minY; 
    // Límite superior de la pantalla
    public float maxY;
    public float minZ;
    public float maxZ;

    
    void Update()
    {
        
        Vector3 cursorPosition = Input.mousePosition;
        //Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(cursorPosition.x, cursorPosition.y, 10f));
        Vector3 targetPosition = Vector3.zero;
        
        float normalizedMousePosition_y = cursorPosition.y/Screen.height;
        float normalizedMousePosition_x = cursorPosition.x / Screen.width;

        targetPosition.x = Mathf.Lerp(minX, maxX, normalizedMousePosition_x);
        targetPosition.y = Mathf.Lerp(minY, maxY, normalizedMousePosition_y);
        targetPosition.z = transform.position.z;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            targetPosition.z -= Input.GetAxis("Mouse ScrollWheel");
            print(targetPosition.z);
            //targetPosition.z = Mathf.Clamp(targetPosition.z, -5f, -4f);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            targetPosition.z -= Input.GetAxis("Mouse ScrollWheel");
            print(targetPosition.z);
            //targetPosition.z = Mathf.Clamp(targetPosition.z, -4f, -5f);
        }

        // Set the arm's position
        transform.position = targetPosition;
    }

}
