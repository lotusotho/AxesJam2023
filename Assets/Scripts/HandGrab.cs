using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
    private GameObject currentGrabbedItem;

    private GameObject lastSelectedItem;

    public Transform grabPosition;

    public LayerMask grabLayer;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Grabbable"))
        {
            lastSelectedItem = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Grabbable"))
        {
            lastSelectedItem = null;
        }
    }

    private void Update()
    {
        if (lastSelectedItem != null)
        {
            CheckGrabOrDropItem();
        }
    }

    private void CheckGrabOrDropItem()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (currentGrabbedItem == null)
            {
                lastSelectedItem.transform.position = grabPosition.position;
                lastSelectedItem.transform.SetParent(grabPosition, true);
                
                currentGrabbedItem = lastSelectedItem;
            }
            else
            {
                lastSelectedItem.transform.parent = null;
                currentGrabbedItem = null;
                
            }
          
            
        }
    }
}
