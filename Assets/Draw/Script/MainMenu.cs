using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingPanel;
    public bool soundOn = true;
    public AudioSource audioSource;
    public Button soundButton, musicButton;
    public Sprite soundOnSprite, soundOffSprite, musicOnSprite, musicOffSprite;
    
    void Start()
    {
        settingPanel.active = false;
    }

    void Update()
    {
        
    }

    public void soundButtonClick()
    {
        soundOn = !soundOn;
        if (soundOn) soundButton.GetComponent<Image>().sprite = soundOnSprite;
        else soundButton.GetComponent<Image>().sprite = soundOffSprite;
    }

    public void musicButtonClick()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }
        else
        {
            audioSource.Play();
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
    }

    public void settingButtonClick()
    {
        settingPanel.active = !settingPanel.active;
    }
}