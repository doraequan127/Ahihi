using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class Quan_ly_cac_ham : MonoBehaviour
    {
        public GameObject Panel_GameOver, Panel_Pause;
        public Text Text_ScoreFigure, Text_Score, Text_HighScoreFigure;
        public GameObject Enemy, RockBig, RockSmall;
        public AudioClip sound_YellowBullet, sound_RedBullet, sound_Explode, sound_Explode2;
        public AudioSource audioSource;

        private int Điểm = 0;

        private void Awake()
        {
            StartCoroutine(Sinh_ra_Enemy());
            StartCoroutine(Sinh_ra_RockBig());
            StartCoroutine(Sinh_ra_RockSmall());
        }

        private void Update()
        {
            Text_Score.text = "Score: " + Điểm;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Panel_Pause.active)
                    button_Resume();
                else button_Pause();
            }
        }

        public void playSound_Explode()
        {
            audioSource.PlayOneShot(sound_Explode, 2);
        }

        public void playSound_Explode2()
        {
            audioSource.PlayOneShot(sound_Explode2, 4);
        }

        public void playSound_YellowBullet()
        {
            audioSource.PlayOneShot(sound_YellowBullet);
        }

        public void playSound_RedBullet()
        {
            audioSource.PlayOneShot(sound_RedBullet);
        }

        public void Tăng_điểm()
        {
            Điểm++;
        }

        public void Gọi_PanelGameOver()
        {
            StartCoroutine(Gọi__PanelGameOver());
        }

        public void button_Pause()
        {
            Time.timeScale = 0;
            Panel_Pause.SetActive(true);
        }

        public void button_Resume()
        {
            Panel_Pause.SetActive(false);
            Time.timeScale = 1;
        }

        public void button_MainMenu()
        {
            Panel_GameOver.SetActive(false);
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        public void button_ResetHighScore()
        {
            PlayerPrefs.DeleteAll();
        }

        IEnumerator Sinh_ra_Enemy()
        {
            yield return new WaitForSeconds(Random.Range(0.3f, 0.7f));
            Vector3 Tọa_độ_Enemy = new Vector3(Random.Range(-2.7f, 2.7f), 5.5f);
            Instantiate(Enemy, Tọa_độ_Enemy, Quaternion.identity);
            StartCoroutine(Sinh_ra_Enemy());
        }

        IEnumerator Sinh_ra_RockBig()
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            Vector3 Tọa_độ_RockBig = new Vector3(Random.Range(-2.7f, 2.7f), 5.5f);
            Instantiate(RockBig, Tọa_độ_RockBig, Quaternion.identity);
            StartCoroutine(Sinh_ra_RockBig());
        }

        IEnumerator Sinh_ra_RockSmall()
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            Vector3 Tọa_độ_RockSmall = new Vector3(Random.Range(-2.8f, 2.8f), 5.5f);
            Instantiate(RockSmall, Tọa_độ_RockSmall, Quaternion.identity);
            StartCoroutine(Sinh_ra_RockSmall());
        }

        IEnumerator Gọi__PanelGameOver()
        {
            yield return new WaitForSeconds(1f);
            Text_ScoreFigure.text = Điểm + "";
            if (Điểm > PlayerPrefs.GetInt("HighScore", 0))
                PlayerPrefs.SetInt("HighScore", Điểm);
            Text_HighScoreFigure.text = PlayerPrefs.GetInt("HighScore", 0) + "";
            Panel_GameOver.SetActive(true);
            yield return new WaitForSeconds(1f);
            Time.timeScale = 0;
        }
    }
}