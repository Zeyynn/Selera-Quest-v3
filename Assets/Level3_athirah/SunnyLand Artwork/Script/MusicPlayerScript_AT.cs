using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript_AT : MonoBehaviour
{
    private List<AudioSource> audioSources = new List<AudioSource>();
    public Slider volumeSlider;
    private float musicVolume = 0f;

    void Start()
    {
    
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("GameMusic");
        foreach (GameObject obj in musicObjects)
        {
            AudioSource audioSource = obj.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSources.Add(audioSource);
            }
        }

        musicVolume = PlayerPrefs.GetFloat("volume");
        SetVolume(musicVolume);
        volumeSlider.value = musicVolume;
    }

    void Update()
    {
        SetVolume(musicVolume);
        PlayerPrefs.SetFloat("volume", musicVolume);
    }
    
    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
        SetVolume(musicVolume);
    }
    
    public void MusicReset()
    {
        PlayerPrefs.DeleteKey("volume");
        musicVolume = 1;
        SetVolume(musicVolume);
        volumeSlider.value = 1;
    }
    
    private void SetVolume(float volume)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }
}