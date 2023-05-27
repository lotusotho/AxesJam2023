using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehaviour : MonoBehaviour
{

    private Vector3 pos;
    public float speed = 3f;
    
    
    // Update is called once per frame
    void Update()
    {

        pos = Input.mousePosition;
        pos.z = speed;
        //Vector3 cameraPos = Camera.main.ScreenToWorldPoint(pos);
        
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

       transform.Translate(new Vector3(x, y ,0));


    }
    
}
