using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Platformer; // Add this line to include the Platformer namespace

public class ItemCollect_AZ : MonoBehaviour
{
    private int point = 0;
    private int item = 0;
    public int nextlevelpoint;
    public string nextlevel;
    [SerializeField] private Text pointText;
    [SerializeField] private Text pointText1;
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private AudioSource itemSoundEffect;
    [SerializeField] private AudioSource lifeSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Money"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            point++;
            pointText.text = "Total coins: " + point;
        }
        if (collision.gameObject.CompareTag("Item"))
        {
            itemSoundEffect.Play();
            Destroy(collision.gameObject);
            item++;
            pointText1.text = "Items collected: " + item;
        }
        if (collision.gameObject.CompareTag("Life"))
        {
            PlayerController_AZ playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController_AZ>();
            if (playerController != null)
            {
                lifeSoundEffect.Play();
                playerController.IncreaseLife();
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            if (item >= nextlevelpoint)
            {
                Invoke("LoadLevelGame", 0.5f);
            }
            else
            {
                SceneManager.LoadScene("Game Over - Lvl 1");
            }
        }
    }

    void LoadLevelGame()
    {
        SceneManager.LoadScene(nextlevel);
    }
}