using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;
    public string sceneName;

    private void Update()
    {
        if (_healthSystem.currentHealth == 0)
        {
            Debug.Log("öldün");
            SceneManager.LoadScene(sceneName);
        }
    }
}
