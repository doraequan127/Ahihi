using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    GameObject map, player;
    int playerTranslateCount = 1;
    Vector3 nextNode;
    bool autoMove = false;
    public GameObject target;
    public int[,] isGone = new int[13, 10]
    {
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0 }
    };
    struct position{ public int x; public int y;}
    List<position> stack = new List<position>();
    List<position> wayToWin = new List<position>();
    bool wayToWinFinded = false;
    int countWayToWin = 0;

    bool canGo(int i, int j)
    {
        if (i > 0) if (isGone[i - 1, j] == 0) return true;
        if (i < 12) if (isGone[i + 1, j] == 0) return true;
        if (j > 0) if (isGone[i, j - 1] == 0) return true;
        if (j < 9) if (isGone[i, j + 1] == 0) return true;
        return false;
    }

    void Start()
    {
        map = GameObject.Find("Map");
        player = GameObject.Find("Player");
        isGone[0, 0] = 1;
        stack.Add(new position() { x = 0, y = 0 });
        int i = 0, j = 0;
        while (stack.Count > 0)
        {
            i = stack[stack.Count - 1].x;
            j = stack[stack.Count - 1].y;
            if (canGo(i, j))
            {
                ChooseDirection:
                switch (Mathf.Round(Random.Range(0.51f, 4.49f)))
                {
                    case 1:
                        if (i == 12) goto ChooseDirection;
                        if (isGone[i + 1, j] == 1) goto ChooseDirection;
                        map.transform.GetChild(i).transform.GetChild(j).GetChild(1).gameObject.active = false;
                        i++;
                        break;
                    case 2:
                        if (j == 9) goto ChooseDirection;
                        if (isGone[i, j + 1] == 1) goto ChooseDirection;
                        map.transform.GetChild(i).transform.GetChild(j).GetChild(0).gameObject.active = false;
                        j++;
                        break;
                    case 3:
                        if (i == 0) goto ChooseDirection;
                        if (isGone[i - 1, j] == 1) goto ChooseDirection;
                        map.transform.GetChild(i - 1).transform.GetChild(j).GetChild(1).gameObject.active = false;
                        i--;
                        break;
                    case 4:
                        if (j == 0) goto ChooseDirection;
                        if (isGone[i, j - 1] == 1) goto ChooseDirection;
                        map.transform.GetChild(i).transform.GetChild(j - 1).GetChild(0).gameObject.active = false;
                        j--;
                        break;
                }
                stack.Add(new position() { x = i, y = j });
                isGone[i, j] = 1;
                if ((i == 0 || i == 12) && (j == 0 || j == 9) && !wayToWinFinded)
                {
                    countWayToWin++;
                    if (countWayToWin == 2)
                    {
                        wayToWin.AddRange(stack);
                        wayToWinFinded = true;
                        Instantiate(target, map.transform.GetChild(i).transform.GetChild(j).transform.position, Quaternion.identity); ;
                    }
                }
            }
            else stack.RemoveAt(stack.Count - 1);
        }
        nextNode = map.transform.GetChild(wayToWin[1].x).transform.GetChild(wayToWin[1].y).transform.position;
    }


    void Update()
    {
        if (playerTranslateCount < wayToWin.Count && autoMove)
        {
            if (player.transform.position == nextNode && playerTranslateCount < wayToWin.Count - 1)
            {
                playerTranslateCount++;
                nextNode = map.transform.GetChild(wayToWin[playerTranslateCount].x).transform.GetChild(wayToWin[playerTranslateCount].y).transform.position;
            }
            player.transform.position = Vector2.MoveTowards(player.transform.position, nextNode, 0.06f);
        }
    }

    public void FindButton()
    {
        foreach (position q in wayToWin)
            map.transform.GetChild(q.x).transform.GetChild(q.y).GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void AutoMoveButton()
    {
        autoMove = true;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextButton()
    {
        SceneManager.LoadScene("Game");
    }
}
