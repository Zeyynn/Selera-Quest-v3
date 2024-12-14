using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_AT : MonoBehaviour
{
    public GameObject quitScreen; // Changed from MainMenu to GameObject
    public bool isNext;

    private void Awake()
    {
        // instance = this; // Removed this line as 'instance' is not defined
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleQuitScreen();
        }
    }

    public void ToggleQuitScreen() // Renamed to avoid conflict with Application.Quit method
    {
        if (isNext)
        {
            isNext = false;
            quitScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isNext = true;
            quitScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Level3");
    }

    public void StartLevelAgain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame() // Uncommented and defined correctly
    {
        Application.Quit();
        Debug.Log("Game is Exiting");
    }
}
