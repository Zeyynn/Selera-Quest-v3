using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_AZ : MonoBehaviour
{
    public GameObject MainMenuCanvas;   // Reference to the Main Menu Canvas
    public GameObject LevelSelectCanvas; // Reference to the Level Select Canvas

    void Start()
    {
        // Ensure the main menu is active and the level select menu is inactive at the start
        MainMenuCanvas.SetActive(true);
        LevelSelectCanvas.SetActive(false);
    }

    void Update()
    {
        // This method is intentionally left empty
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LevelSelect()
    {
        // Hide the main menu canvas and show the level select canvas
        MainMenuCanvas.SetActive(false);
        LevelSelectCanvas.SetActive(true);
    }

    public void GotoMain()
    {
        // Show the main menu canvas and hide the level select canvas
        MainMenuCanvas.SetActive(true);
        LevelSelectCanvas.SetActive(false);
    }
    public void ExitGame()
    {
        // Exit the game
        Application.Quit();
    }
}