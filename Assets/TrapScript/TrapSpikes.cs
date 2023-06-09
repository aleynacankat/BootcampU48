using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roundbeargames
{
    public class TrapSpikes : MonoBehaviour
    {
        public List<CharacterController> ListCharactres = new List<CharacterController>();

        private void Start()
        {
            ListCharactres.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            CharacterController control = other.gameObject.transform.root.gameObject.GetComponent<CharacterController>();
            if (control != null)
            {
                if (!ListCharactres.Contains(control))
                {
                    ListCharactres.Add(control);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            CharacterController control = other.gameObject.transform.root.gameObject.GetComponent<CharacterController>();
            if (control != null)
            {
                if (ListCharactres.Contains(control))
                {
                    ListCharactres.Remove(control);
                }
            }
        }
    }
}
