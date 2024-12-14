using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollect_AT : MonoBehaviour
{
    private int point = 0; 
    public int nextlevelpoint; 
    public string nextlevel; 
    [SerializeField] private Text pointText;
    [SerializeField] private AudioSource collectSoundEffect; 
    public ParticleSystem gemparticle; 
        
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("Reward"))
        {
            collectSoundEffect.Play(); 
            Instantiate(gemparticle, transform.position, Quaternion.identity); 
            Destroy(collision.gameObject);
            point ++;
            pointText.text = "Point: " + point;
        } 

        if (collision.gameObject.CompareTag("Finish"))
        {
            if (point >= nextlevelpoint)
            {
                Invoke("LoadLevelGame", 0.5f); 
            }
            else
            {
                Debug.Log("Game Over"); 
            }
        }
    }

    void LoadLevelGame() 
    {
        SceneManager.LoadScene(nextlevel); 
    }
}