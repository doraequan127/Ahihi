using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlappyBird
{
    public class Quan_ly_cac_ham : MonoBehaviour
    {
        public AudioClip sound_Fly, sound_Ping, sound_Dead;
        public GameObject Pipe;
        public bool is_Died;

        private AudioSource audioSource;
        private int Điểm = 0;
        private GameObject Panel_GameOver;    //Đầu tiên phải setActive(true) cho Panel này đã
        private Text Text_Score, Text_Score1, Text_HighScore;

        private void Awake()
        {
            audioSource = GameObject.Find("Quan_ly_cac_ham").GetComponent<AudioSource>();
            Panel_GameOver = GameObject.Find("Panel_GameOver");
            Text_Score = GameObject.Find("Text_Score").GetComponent<Text>();
            Text_Score1 = GameObject.Find("Text_Score1").GetComponent<Text>();
            Text_HighScore = GameObject.Find("Text_HighScore").GetComponent<Text>();
            Panel_GameOver.SetActive(false);   //rồi sau đó setActive(false) ở đây (giải thích cho điều 19 trong Học_Unity.docx)
            Time.timeScale = 0;
            StartCoroutine(Sinh_ra_Pipe());
        }

        public void button_Menu()
        {
            SceneManager.LoadScene("Flappy Bird Scene 1");
            Time.timeScale = 1;
        }

        public void button_Replay()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void button_TapToPlay()
        {
            GameObject.Find("Button_TapToPlay").SetActive(false);
            Time.timeScale = 1;
        }

        public void playSound_Fly()
        {
            audioSource.PlayOneShot(sound_Fly);
        }

        public void eatScore()
        {
            audioSource.PlayOneShot(sound_Ping);
            Điểm++;
            Text_Score.text = Điểm + "";
        }

        public void GameOver()
        {
            StartCoroutine(GameOver_());
        }

        IEnumerator Sinh_ra_Pipe()
        {
            yield return new WaitForSeconds(1.5f);
            Vector3 Tọa_độ_Pipe = new Vector3(3.5f, Random.Range(2f, 6.8f));
            Instantiate(Pipe, Tọa_độ_Pipe, Quaternion.identity);
            StartCoroutine(Sinh_ra_Pipe());
        }

        IEnumerator GameOver_()
        {
            is_Died = true;
            audioSource.PlayOneShot(sound_Dead);
            yield return new WaitForSeconds(1);
            Panel_GameOver.SetActive(true);
            Text_Score1.text = Điểm + "";
            if (Điểm > PlayerPrefs.GetInt("Flappy Bird HighScore"))
                PlayerPrefs.SetInt("Flappy Bird HighScore", Điểm);
            Text_HighScore.text = PlayerPrefs.GetInt("Flappy Bird HighScore", 0) + "";
            yield return new WaitForSeconds(2);
            Time.timeScale = 0;
        }
    }
}