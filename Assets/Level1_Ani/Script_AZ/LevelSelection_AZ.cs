using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection_AZ : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    public void StartLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void StartLevel4()
    {
        SceneManager.LoadScene("QUEST");
    }
    public void GotoMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}