using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehaviour : MonoBehaviour
{
    public float minX; // Límite izquierdo de la pantalla
    public float maxX; // Límite derecho de la pantalla
    public float minY; // Límite inferior de la pantalla
    public float maxY; // Límite superior de la pantalla

    void Update()
    {
        Vector3 cursorPosition = Input.mousePosition;
        
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(cursorPosition.x, cursorPosition.y, 10f));
        
        targetPosition.z = transform.position.z;

        // Limitar la posición del objeto dentro de los límites de la pantalla utilizando Mathf.Clamp
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        // Asignar la posición del objeto después de aplicar los límites
        transform.position = targetPosition;
    }

}
