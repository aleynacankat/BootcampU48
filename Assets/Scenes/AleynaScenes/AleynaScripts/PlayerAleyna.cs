using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAleyna : MonoBehaviour
{

    public float moveSpeed = 7f;
    public Inventory inventory;

    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if  (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed *Time.deltaTime;

        

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }

    }
}
