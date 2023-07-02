using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeteScript : MonoBehaviour
{
    [SerializeField] GameObject GazeteUIGO;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gazete"))
        {
            GazeteUIGO.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Gazete"))
        {
            GazeteUIGO.SetActive(false);
        }
    }
}
