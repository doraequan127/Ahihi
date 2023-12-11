using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour
{
    [SerializeField] Color inkColor;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] GameObject winPanel;
    [SerializeField] Button nextButton;
    [SerializeField] Text levelText;
    Vector3 mousePos, Pos, previousPos;
    public List<Vector3> linePositions = new List<Vector3>();
    public float minimumDistance = 0.05f;
    float distance = 0;
    public List<GameObject> level = new List<GameObject>();
    GameObject currentLevel;
    int levelIndex = 0;
    int nodeIndex = 0;

    void Start()
    {
        lineRenderer.material.color = inkColor;
        currentLevel = Instantiate(level[levelIndex], Vector2.zero, Quaternion.identity);
        nextButton.onClick.AddListener(() =>
        {
            if (levelIndex == level.Count - 1) return;
            levelIndex++;
            Destroy(currentLevel);
            currentLevel = Instantiate(level[levelIndex], Vector2.zero, Quaternion.identity);
            linePositions.Clear();
            lineRenderer.positionCount = linePositions.Count;
            lineRenderer.SetPositions(linePositions.ToArray());
            winPanel.SetActive(false);
            levelText.text = "Level " + (levelIndex + 1);
        });
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            linePositions.Clear();
            mousePos = Input.mousePosition;
            mousePos.z = 0.5f;
            Pos = Camera.main.ScreenToWorldPoint(mousePos);
            previousPos = Pos;
            linePositions.Add(Pos);

            nodeIndex = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 0.5f;
            Pos = Camera.main.ScreenToWorldPoint(mousePos);
            distance = Vector2.Distance(Pos, previousPos);
            if (distance >= minimumDistance)
            {
                previousPos = Pos;
                linePositions.Add(Pos);
                lineRenderer.positionCount = linePositions.Count;
                lineRenderer.SetPositions(linePositions.ToArray());

                if (nodeIndex < currentLevel.transform.childCount)
                {
                    if (Vector2.Distance(Pos, currentLevel.transform.GetChild(nodeIndex).transform.position) < 0.2f)
                        nodeIndex++;
                }
                else
                {
                    print("You win!");
                    winPanel.active = true;
                }
            }
        }
    }
}
