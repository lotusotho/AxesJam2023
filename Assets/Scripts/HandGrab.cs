using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
    private GameObject currentGrabbedItem;

    private GameObject lastSelectedItem;

    private float timerDropFood;

    private float totalTimeDropFood = 0.1f;

    private bool isDropping = false;

    private BoxCollider collider;
    
    public Transform grabPosition;

    public LayerMask grabLayer;

    public int layerMask_grabable;
    public int layerMask_grabableFinished;
    
    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        layerMask_grabable = LayerMask.GetMask(new[] { "Grabbable" });
        layerMask_grabableFinished = LayerMask.GetMask(new[] { "GrababbleFinished" });
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
            timerDropFood += Time.deltaTime;
            if (timerDropFood > totalTimeDropFood)
            {
                timerDropFood = 0f;
                
                collider.isTrigger = false;
                isDropping = false;
            }
        }
        
        if (lastSelectedItem != null || currentGrabbedItem != null)
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
                Debug.Log("Cogemos");
                lastSelectedItem.transform.position = grabPosition.position;
                lastSelectedItem.transform.SetParent(grabPosition, true);
                
                currentGrabbedItem = lastSelectedItem;
                currentGrabbedItem.GetComponent<Rigidbody>().isKinematic = true;
            }
            //Dropeamos el objeto
            else
            {
                Debug.Log("Dropeamos");
                currentGrabbedItem.GetComponent<Rigidbody>().isKinematic = false;
                collider.isTrigger = true;
                currentGrabbedItem.transform.parent = null;
                isDropping = true;
                
                currentGrabbedItem = null;
                
            }
            
        }
    }
}
