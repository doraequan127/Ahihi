using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyBird
{
    public class MainMenu_ : MonoBehaviour
    {
        public void button_Play()
        {
            SceneManager.LoadScene("Flappy Bird Scene 2");
        }
    }
}