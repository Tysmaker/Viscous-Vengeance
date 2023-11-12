using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{  
    public GameObject pausePanel;
    private bool isPaused = false;

    private GameObject levelManager;
    private LevelManager levelManagerScript;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager");
        levelManagerScript = levelManager.GetComponent<LevelManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }    
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        levelManagerScript.loadMainMenu();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
