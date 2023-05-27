using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
    private GameObject currentGrabbedItem;

    private GameObject lastSelectedItem;

    private float timerDropFood;

    private float totalTimeDropFood = 0.5f;

    private bool isDropping = false;

    private BoxCollider collider;
    
    public Transform grabPosition;

    public LayerMask grabLayer;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Grabbable") || collision.gameObject.layer == LayerMask.NameToLayer("GrababbleFinished"))
        {
            lastSelectedItem = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Grabbable") || other.gameObject.layer == LayerMask.NameToLayer("GrababbleFinished"))
        {
            lastSelectedItem = null;
        }
    }

    private void Update()
    {

        if (isDropping)
        {
            if (timerDropFood < totalTimeDropFood)
            {
                timerDropFood += Time.deltaTime;
            }
            else
            {
                collider.isTrigger = false;
                timerDropFood = 0f;
                isDropping = false;
                
            }
        }
        
        if (lastSelectedItem != null)
        {
            CheckGrabOrDropItem();
        }
    }

    private void CheckGrabOrDropItem()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Cogemos el objeto
            if (currentGrabbedItem == null)
            {
                lastSelectedItem.transform.position = grabPosition.position;
                lastSelectedItem.transform.SetParent(grabPosition, true);
                
                currentGrabbedItem = lastSelectedItem;
            }
            //Dropeamos el objeto
            else
            {
                collider.isTrigger = true;
                isDropping = true;
                lastSelectedItem.transform.parent = null;
                currentGrabbedItem = null;
                
            }
            
        }
    }
}
