using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SQ2VictoryMenu : MonoBehaviour
{
    public static SQ2VictoryMenu instance;
    public string nextLevel, mainMenu;

    public GameObject pauseScreen;
    public bool isPaused;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update 
    void Start()
    {

    }

    // Update is called once per frame 

    public void LevelSelect()
    {
        PlayerPrefs.SetString("QUEST", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(nextLevel);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

}