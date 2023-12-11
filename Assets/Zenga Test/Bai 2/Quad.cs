using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour
{
    Vector3 screenPointOfQuad, first, second;
    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        screenPointOfQuad = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            first = Input.mousePosition - screenPointOfQuad;
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                second = Input.mousePosition - screenPointOfQuad;
                transform.Rotate(0, 0, Vector3.SignedAngle(first, second, new Vector3(0, 0, 1)));
                first = second;
            }
        }
    }
}
