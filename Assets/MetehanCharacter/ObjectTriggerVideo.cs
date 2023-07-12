using System.Collections;
using UnityEngine;

public class DisplayUI : MonoBehaviour
{
    public GameObject uiElement;
    public GameObject HealthBarCanvas;
    public GameObject CanvasInventory;
    public GameObject QuestInfo;

    private bool hasTriggered = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered) 
        {
            hasTriggered = true; 
            uiElement.SetActive(true);
            HealthBarCanvas.SetActive(false);
            QuestInfo.SetActive(false);
            CanvasInventory.SetActive(false);
            StartCoroutine(WaitAndHideUI(10f)); 
        }
    }

    IEnumerator WaitAndHideUI(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); 
        uiElement.SetActive(false);
        HealthBarCanvas.SetActive(true);
        QuestInfo.SetActive(true);
        CanvasInventory.SetActive(true);
    }
}


