using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{  
    public GameObject pausePanel;
    private bool isPaused = false;

    private GameObject levelManagerObject;
    private LevelManager levelManager;
    private GameObject soundManagerObject;
    private SoundManager soundManager;

    private void Start()
    {
        levelManagerObject = GameObject.Find("LevelManager");
        levelManager = levelManagerObject.GetComponent<LevelManager>();
        soundManagerObject = GameObject.Find("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            soundManager.Pause("BG_Level1");
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            isPaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            soundManager.Play("BG_Level1");
        }    
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        levelManager.loadMainMenu();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
