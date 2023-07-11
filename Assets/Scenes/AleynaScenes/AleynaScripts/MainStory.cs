using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    public string _sahnename;
    void OnEnable()
    {
        //Only specifiying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene(_sahnename, LoadSceneMode.Single);
    }

}
