using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStoryDD : MonoBehaviour
{
    void OnEnable()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        
        int nextSceneIndex = currentSceneIndex + 1;

        
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        
        SceneManager.LoadScene(nextSceneIndex);
    }
}
