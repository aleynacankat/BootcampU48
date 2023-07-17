using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStoryD : MonoBehaviour
{
    void OnEnable()
    {
        //Only specifiying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("2CutsceneYazi99", LoadSceneMode.Single);
    }

}