using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor.ShaderGraph;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class ItemPickUp : MonoBehaviour
{
    public float PickUpRadius = 1f;
    public InventoryItemData ItemData;

    private SphereCollider myCollider;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = PickUpRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<InventoryHolder>();

        if (!inventory) return;

        if (inventory.InventorySystem.AddToInventory(ItemData, 1))
        {
            if (ItemData.ID == 0 && ItemData.DisplayName == "Seed")
            {
                Destroy(this.gameObject, 11f); 
            }
            else
            {
                Destroy(this.gameObject); 
            }
        }
    }
}
