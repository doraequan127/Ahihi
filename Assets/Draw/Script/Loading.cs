using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    float time = 3, currentTime = 0;
    GameObject loadingBar;

    void Start()
    {
        loadingBar = GameObject.Find("Loading Bar");
    }


    void Update()
    {
        currentTime += Time.deltaTime;
        //if (currentTime > time) SceneManager.LoadScene("2. Game");
        loadingBar.GetComponent<Slider>().value = currentTime / time;
    }
}
