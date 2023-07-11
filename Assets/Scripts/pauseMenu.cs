using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject HealthBarCanvas;
    public GameObject CanvasInventory;
    public GameObject QuestInfo;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        HealthBarCanvas.SetActive(true);
        QuestInfo.SetActive(true);
        CanvasInventory.SetActive(true);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        HealthBarCanvas.SetActive(false);
        QuestInfo.SetActive(false);
        CanvasInventory.SetActive(false);
        Time.timeScale = 0.1f;
        GamePaused = true;

    }

    public void LoadMenu ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("0StartScene");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
