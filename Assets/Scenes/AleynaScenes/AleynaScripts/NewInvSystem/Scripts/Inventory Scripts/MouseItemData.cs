using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseItemData : MonoBehaviour
{
    public Image ItemSprite;
    public TextMeshProUGUI ItemCount;
    public InventorySlot AssignedInventorySlot;

    private void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";
    }

    public void UpdateMouseSlot(InventorySlot invSlot)
    {
        AssignedInventorySlot.AssignItem(invSlot);
        ItemSprite.sprite = invSlot.ItemData.Icon;
        ItemCount.text = invSlot.StackSize.ToString();
        ItemSprite.color = Color.white;
    }
}
