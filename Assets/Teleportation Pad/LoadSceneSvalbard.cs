using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneSvalbard : MonoBehaviour

{
    public string sceneName;
    private IEnumerator DelayedTrigger(Collider other)
    {
        yield return new WaitForSeconds(0.5f);
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DelayedTrigger(other));
        }
    }
}
