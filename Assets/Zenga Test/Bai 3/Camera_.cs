using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ : MonoBehaviour
{
    float first, second;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            first = Input.mousePosition.x;
        if (Input.GetMouseButton(0))
        {
            second = Input.mousePosition.x;
            transform.Rotate(0, (first - second) * 0.15f, 0);
            first = second;
        }
    }
}
