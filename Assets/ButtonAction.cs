using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private GameObject _RestartButton;

    public HealthSystem _healthSystem;
    private void Start()
    {
        _RestartButton.SetActive(false);
    }
    
    private void Update()
    {
        if (_healthSystem.currentHealth == 0)
        {
           _RestartButton.SetActive(true);
        }
    }
    
            
    
    public void ButtonActionFonk()
    {
        SceneManager.LoadScene(sceneName);
        _RestartButton.SetActive(false);
    }
}

