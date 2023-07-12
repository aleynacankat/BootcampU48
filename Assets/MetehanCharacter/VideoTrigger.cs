using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTrigger : MonoBehaviour
{
    public GameObject VideoUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VideoUI.SetActive(true);
            Invoke("HideUI", 10f);
        }
    }

    void HideUI()
    {
        VideoUI.SetActive(false);
    }
}
