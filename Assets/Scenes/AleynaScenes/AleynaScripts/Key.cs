using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "Key";
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }
    
    public void OnPickup()
    {
        //ToDo: add logic what happens when key is picked up by player (for our sword)

        gameObject.SetActive(false);
    }

}
