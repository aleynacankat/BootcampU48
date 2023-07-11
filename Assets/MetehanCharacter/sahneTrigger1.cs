using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sahneTrigger1 : MonoBehaviour
{

    public GameObject VideoUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VideoUI.SetActive(true);
            StartCoroutine(WaitAndHideUI(10f));
        }
    }
    
    IEnumerator WaitAndHideUI(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        VideoUI.SetActive(false);
    }
}
