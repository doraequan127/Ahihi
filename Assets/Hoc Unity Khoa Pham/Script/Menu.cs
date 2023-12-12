using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace khoapham
{
    public class Menu : MonoBehaviour
    {
        public AudioClip sound1;
        public AudioSource audioSource;

        public void button_StartGame()
        {
            audioSource.PlayOneShot(sound1);
            SceneManager.LoadScene(1);
        }

        public void button_Exit()
        {
            Application.Quit();
        }
    }
}