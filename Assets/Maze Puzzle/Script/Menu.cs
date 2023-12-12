using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject content;
    public List<GameObject> stages = new List<GameObject>();
    int bottomRow = 0;
    int topRow()
    {
        if (bottomRow > 0) return bottomRow - 1;
        return 9;
    }
    int currentRow = 0;
    float firstMousePosition, firstContentPosition, preContentPosition, currentContentPosition;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("Current Level"))
        {
            PlayerPrefs.SetInt("Current Level", Mathf.RoundToInt(Random.Range(-0.49f, 999.49f)));
            for (int i = 0; i < PlayerPrefs.GetInt("Current Level"); i++)
                PlayerPrefs.SetInt(i + "", Mathf.RoundToInt(Random.Range(0.51f, 3.49f)));
        }
        print(PlayerPrefs.GetInt("Current Level"));
        for (int i = 0; i < 40; i++)
        {
            if (i == 0) stages[i].transform.Find("Level Number").GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
            else stages[i].transform.Find("Tutorial Image").GetComponent<Image>().color = new Color(1, 1, 1, 0);
            if (int.Parse(stages[i].name) <= PlayerPrefs.GetInt("Current Level"))
                stages[i].transform.Find("Stage Lock").GetComponent<Image>().color = new Color(1, 1, 1, 0);
            if (int.Parse(stages[i].name) < PlayerPrefs.GetInt("Current Level"))
                for (int u = 1; u <= 3; u++)
                    stages[i].transform.Find("Star " + u).GetComponent<Image>().color = new Color(1, 1, 1, u <= PlayerPrefs.GetInt(stages[i].name) ? 1 : 0);
            else
                for (int u = 1; u <= 3; u++)
                    stages[i].transform.Find("Star " + u).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            if (int.Parse(stages[i].name) <= PlayerPrefs.GetInt("Current Level"))
                stages[i].transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Game"));
        }
        firstContentPosition = content.GetComponent<RectTransform>().anchoredPosition.y;
        preContentPosition = firstContentPosition;
    }

    private void Update()
    {
        currentContentPosition = content.GetComponent<RectTransform>().anchoredPosition.y;
        if (currentContentPosition - preContentPosition > 0 && currentRow > 0 && content.GetComponent<RectTransform>().anchoredPosition.y > firstContentPosition - 124 * currentRow)
        {
            currentRow--;
            for (int i = 0; i < 4; i++)
            {
                stages[topRow() * 4 + i].GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, 124 * 10);
                if (currentRow == 0 && i == 0)
                {
                    stages[topRow() * 4 + i].transform.Find("Level Number").GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
                    stages[topRow() * 4 + i].transform.Find("Tutorial Image").GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    stages[topRow() * 4 + i].name = 0 + "";
                }
                else
                {
                    stages[topRow() * 4 + i].transform.Find("Level Number").GetComponent<TextMeshProUGUI>().color = new Color(1, 0, 0, 1);
                    stages[topRow() * 4 + i].transform.Find("Tutorial Image").GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    stages[topRow() * 4 + i].name = (int.Parse(stages[topRow() * 4 + i].name) - 40) + "";
                    stages[topRow() * 4 + i].transform.Find("Level Number").GetComponent<TextMeshProUGUI>().text = (int.Parse(stages[topRow() * 4 + i].name) + 1) + "";
                }
                if (int.Parse(stages[topRow() * 4 + i].name) <= PlayerPrefs.GetInt("Current Level"))
                    stages[topRow() * 4 + i].transform.Find("Stage Lock").GetComponent<Image>().color = new Color(1, 1, 1, 0);
                else
                    stages[topRow() * 4 + i].transform.Find("Stage Lock").GetComponent<Image>().color = new Color(1, 1, 1, 1);
                if (int.Parse(stages[topRow() * 4 + i].name) < PlayerPrefs.GetInt("Current Level"))
                    for (int u = 1; u <= 3; u++)
                        stages[topRow() * 4 + i].transform.Find("Star " + u).GetComponent<Image>().color = new Color(1, 1, 1, u <= PlayerPrefs.GetInt(stages[topRow() * 4 + i].name) ? 1 : 0);
                else
                    for (int u = 1; u <= 3; u++)
                        stages[topRow() * 4 + i].transform.Find("Star " + u).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                if (int.Parse(stages[topRow() * 4 + i].name) <= PlayerPrefs.GetInt("Current Level"))
                    stages[topRow() * 4 + i].transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Game"));
                else stages[topRow() * 4 + i].transform.Find("Button").GetComponent<Button>().onClick.RemoveAllListeners();
            }
            bottomRow--;
            if (bottomRow < 0) bottomRow = 9;
        }
        if (currentContentPosition - preContentPosition < 0 && currentRow < 250 - 10 && content.GetComponent<RectTransform>().anchoredPosition.y < firstContentPosition - 124 * currentRow)
        {
            currentRow++;
            for (int i = 0; i < 4; i++)
            {
                stages[bottomRow * 4 + i].GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 124 * 10);
                stages[bottomRow * 4 + i].transform.Find("Level Number").GetComponent<TextMeshProUGUI>().color = new Color(1, 0, 0, 1);
                stages[bottomRow * 4 + i].transform.Find("Tutorial Image").GetComponent<Image>().color = new Color(1, 1, 1, 0);
                stages[bottomRow * 4 + i].name = (int.Parse(stages[bottomRow * 4 + i].name) + 40) + "";
                stages[bottomRow * 4 + i].transform.Find("Level Number").GetComponent<TextMeshProUGUI>().text = (int.Parse(stages[bottomRow * 4 + i].name) + 1) + "";
                if (int.Parse(stages[bottomRow * 4 + i].name) <= PlayerPrefs.GetInt("Current Level"))
                    stages[bottomRow * 4 + i].transform.Find("Stage Lock").GetComponent<Image>().color = new Color(1, 1, 1, 0);
                else
                    stages[bottomRow * 4 + i].transform.Find("Stage Lock").GetComponent<Image>().color = new Color(1, 1, 1, 1);
                if (int.Parse(stages[bottomRow * 4 + i].name) < PlayerPrefs.GetInt("Current Level"))
                    for (int u = 1; u <= 3; u++)
                        stages[bottomRow * 4 + i].transform.Find("Star " + u).GetComponent<Image>().color = new Color(1, 1, 1, u <= PlayerPrefs.GetInt(stages[bottomRow * 4 + i].name) ? 1 : 0);
                else
                    for (int u = 1; u <= 3; u++)
                        stages[bottomRow * 4 + i].transform.Find("Star " + u).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                if (int.Parse(stages[bottomRow * 4 + i].name) <= PlayerPrefs.GetInt("Current Level"))
                    stages[bottomRow * 4 + i].transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("Game"));
                else stages[bottomRow * 4 + i].transform.Find("Button").GetComponent<Button>().onClick.RemoveAllListeners();
            }
            bottomRow++;
            if (bottomRow > 9) bottomRow = 0;
        }
        preContentPosition = currentContentPosition;
    }

    public void ResetButtonClick()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Current Level", 1);
        SceneManager.LoadScene("Menu");
    }
}
