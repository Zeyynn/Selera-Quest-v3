using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel_AT : MonoBehaviour
{
    public static StartLevel_AT instance;
    public string levelSelect, mainMenu, levelRestart, quitLevelScene; // Renamed quitLevel to quitLevelScene

    public GameObject startScreen;
    public bool isStart;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        if (isStart)
        {
            isStart = false;
            startScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isStart = true;
            startScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    /*public void LevelSelect()
    {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    } */

    public void LevelRestart()
    {
        PlayerPrefs.SetString("Restart Level 3", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(levelRestart);
        Time.timeScale = 1f;
    }

    public void QuitLevel() // Renamed the method to QuitLevel
    {
        SceneManager.LoadScene(quitLevelScene); // Changed to use the renamed field
        Time.timeScale = 1f;
    }
}
