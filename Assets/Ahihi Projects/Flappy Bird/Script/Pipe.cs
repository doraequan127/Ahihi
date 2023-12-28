using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Pipe : MonoBehaviour
    {
        private Quan_ly_cac_ham Quản_lý_các_hàm;

        private void Awake()
        {
            Quản_lý_các_hàm = GameObject.Find("Quan_ly_cac_ham").GetComponent<Quan_ly_cac_ham>();
        }

        private void Update()
        {
            if (!Quản_lý_các_hàm.is_Died)
                transform.position = new Vector3(transform.position.x - 2f * Time.deltaTime, transform.position.y);
            if (transform.position.x < -3.5f)
                Destroy(gameObject);
        }
    }
}