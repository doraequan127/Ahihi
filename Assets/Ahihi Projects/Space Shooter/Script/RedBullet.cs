using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class RedBullet : MonoBehaviour
    {
        public GameObject Explode;

        private Quan_ly_cac_ham Quản_lý_các_hàm;

        private void Awake()
        {
            Quản_lý_các_hàm = GameObject.Find("Quan_ly_cac_ham").GetComponent<Quan_ly_cac_ham>();
            //Quản_lý_các_hàm.playSound_RedBullet();
        }

        private void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 10 * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.name == "WallBelow")
                Destroy(gameObject);
        }
    }
}