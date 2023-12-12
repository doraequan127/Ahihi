using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class YellowBullet : MonoBehaviour
    {
        public GameObject Explode;

        private Quan_ly_cac_ham Quản_lý_các_hàm;

        private void Awake()
        {
            Quản_lý_các_hàm = GameObject.Find("Quan_ly_cac_ham").GetComponent<Quan_ly_cac_ham>();
            Quản_lý_các_hàm.playSound_YellowBullet();
        }

        private void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 5f * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.name == "WallAbove")
                Destroy(gameObject);
            if (collider2D.name == "RockBig(Clone)" || collider2D.name == "RockSmall(Clone)")
            {
                Destroy(gameObject);
                Destroy(collider2D.gameObject);
                Quản_lý_các_hàm.playSound_Explode2();
                Instantiate(Explode, collider2D.transform.position, Quaternion.identity);
            }
            if (collider2D.name == "Enemy(Clone)")
            {
                Destroy(gameObject);
                Destroy(collider2D.gameObject);
                Quản_lý_các_hàm.playSound_Explode();
                Instantiate(Explode, collider2D.transform.position, Quaternion.identity);
                Quản_lý_các_hàm.Tăng_điểm();
            }
        }
    }
}