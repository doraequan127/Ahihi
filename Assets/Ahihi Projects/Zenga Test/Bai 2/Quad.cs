using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZengaTest
{
    public class Quad : MonoBehaviour
    {
        Vector3 screenPointOfQuad, first, second;

        private void Awake()
        {
            screenPointOfQuad = Camera.main.WorldToScreenPoint(transform.position);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                first = Input.mousePosition - screenPointOfQuad;
            if (Input.GetMouseButton(0))
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition)))
                {
                    second = Input.mousePosition - screenPointOfQuad;
                    transform.Rotate(0, 0, Vector3.SignedAngle(first, second, new Vector3(0, 0, 1)));
                    first = second;
                }
        }
    }
}