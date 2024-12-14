using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SQ2HerbCollect : MonoBehaviour
{ 
    public int herbPoint = 0;
    [SerializeField] private Text pointText;
    [SerializeField] private AudioSource collectSoundEffect;

    public void AddHerbPower(int power)
    {
        herbPoint += power;
        if (herbPoint >= 3)
        {
            herbPoint = 3;
        }
        pointText.text = herbPoint + " / 3";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Herb"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            AddHerbPower(1);
        }
    }
}