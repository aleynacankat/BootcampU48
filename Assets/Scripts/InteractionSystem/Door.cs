using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour, Interactable
{
  [SerializeField] private string _prompt;
  public string InteractionPrompt => _prompt;

  public bool Interact(Interactor interactor)
  {
    var inventory = interactor.GetComponent<Inventoryy>();
    if (inventory == null) return false;
    if (inventory.HasKey)
    {
      Debug.Log("Kapi Acildi");
      return true;
    }
    Debug.Log("Key yok");
    return false;
  }
}
