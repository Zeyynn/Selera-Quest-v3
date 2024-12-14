using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IngredientsTagg : MonoBehaviour
{
    public int nextlevelpoint;
    [SerializeField] private GameObject finishPanel, gameOver;
    private int ingre = 0;
    [SerializeField] private Text ingText;
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ingrediends"))
        {
            Destroy(collision.gameObject);
            ingre++;
            ingText.text = "Ingredients : " + ingre + " / 4";
        }
        if (collision.gameObject.CompareTag("Done"))
            if (ingre == nextlevelpoint)
            {
                
                finishPanel.SetActive(true);
            }
            else
            {
                
                gameOver.SetActive(true);
            }
    }

}