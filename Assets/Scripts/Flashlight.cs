using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
   [SerializeField] private GameObject flashlightLight;
   private bool flashlightActive = false;
   private Animator _animator;

   private void Start()
   {
      flashlightLight.gameObject.SetActive(false);
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.L))
      {
         if (flashlightActive == false)
         {
            flashlightLight.gameObject.SetActive(true);
            flashlightActive = true;
         }
         else
         {
            flashlightLight.gameObject.SetActive(false);
            flashlightActive = false;
         }
      }
   }
}
