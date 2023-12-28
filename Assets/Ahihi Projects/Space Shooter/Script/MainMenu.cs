using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class MainMenu : MonoBehaviour
    {
        public void button_Play()
        {
            SceneManager.LoadScene(1);
        }

        public void button_Exit()
        {
            Application.Quit();
        }
    }
}