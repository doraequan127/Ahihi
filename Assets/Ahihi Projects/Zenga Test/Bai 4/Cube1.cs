using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZengaTest
{
    public class Cube1 : MonoBehaviour
    {
        Ray ray;
        RaycastHit hit;
        Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                    rigidbody.linearVelocity = (hit.transform.position - transform.position).normalized * 5;
            }

            if (Input.GetMouseButton(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out hit))
                    rigidbody.linearVelocity = Vector3.zero;
            }

            if (Input.GetMouseButtonUp(0))
                rigidbody.linearVelocity = Vector3.zero;
        }
    }
}