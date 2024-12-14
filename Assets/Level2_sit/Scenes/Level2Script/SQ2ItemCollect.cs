using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SQ2ItemCollect : MonoBehaviour
{
    private int point = 0;
    public int nextlevelpoint;
    public string nextlevel;
    [SerializeField] private Text pointText;
    [SerializeField] private Text levelFailureText;
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private AudioSource victorySoundEffect;
    [SerializeField] private GameObject recipeMenu;

    private void Update()
    {
        HandleExitInput();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Recipe"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            recipeMenu.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Reward"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            point++;
            pointText.text = point + " / 6";
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            if (point >= nextlevelpoint)
            {
                victorySoundEffect.Play();
                Invoke("LoadLevelGame", 0.5f);
            }
            else
            {
                StartCoroutine(DisplayLevelFailureText());
            }
        }
    }
    void LoadLevelGame()
    {
        SceneManager.LoadScene(nextlevel);
    }

    IEnumerator DisplayLevelFailureText()
    {
        levelFailureText.text = "I seem to be forgetting something.";
        yield return new WaitForSeconds(10);
        levelFailureText.text = "";
    }

    private void HandleExitInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            recipeMenu.SetActive(false);
        }
    }
} 
    

