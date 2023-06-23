using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGunScript : MonoBehaviour
{
    public Transform floatPoint;
    public float launchSpeed;

    public Transform targetRange;

    private Camera cam;

    private GameObject target;
    private Rigidbody targetRig;

    public float weaponRange = 12f;

    private bool isAttracting;
    private bool isLaunching;
    
    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        //Attract Input
        if (Input.GetKeyDown(KeyCode.Q))
            isAttracting = true;
        else if (Input.GetKeyUp(KeyCode.Q))
            isAttracting = false;
        
        //Throw with rab;
        if (isAttracting)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                isLaunching = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isAttracting)
            Attarct();
        
        else if (!isAttracting)
            Release();

        if (isLaunching)
        {
            Throw();
        }
    }

    // Method to attract things;
    private void Attarct()
    {
        RaycastHit hit;

        if (target == null)
        {
            if (Physics.Raycast(targetRange.position, targetRange.forward, out hit, weaponRange))
            {
                if (hit.transform.tag == "CanGrab")
                {
                    target = hit.transform.gameObject;
                    targetRig = target.GetComponent<Rigidbody>();
                    target.transform.position = Vector3.MoveTowards(target.transform.position, floatPoint.position, 0.3f);
                    targetRig.useGravity = false;
                }
                
            }
        }
        else
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, floatPoint.position, 0.3f);
        }
    }

    //Method to release an object;
    private void Release()
    {
        if (target != null)
        {
            targetRig.useGravity = true;
            target = null;
        }
    }
    
    //Method to throw an object;
    private void Throw()
    {
        if (targetRig != null)
        {
            targetRig.useGravity = true;
            targetRig.AddForce(floatPoint.transform.forward * launchSpeed, ForceMode.Impulse);
            target = null;
            isLaunching = false;
        }
    }


    private void OnDrawGizmos()
    {
        if (targetRange != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(targetRange.transform.position, targetRange.transform.forward * weaponRange);
        }
    }
}
