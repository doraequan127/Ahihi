using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Enemy : MonoBehaviour
    {
        public GameObject bullet;
        public GameObject explode;

        private Quan_ly_cac_ham Quản_lý_các_hàm;
        private float speed;

        private void Start()
        {
            speed = Random.Range(3f, 8f);
            Quản_lý_các_hàm = GameObject.Find("Quan_ly_cac_ham").GetComponent<Quan_ly_cac_ham>();
            StartCoroutine(Shoot());
        }

        private void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.name == "WallBelow")
                Destroy(gameObject);
        }

        IEnumerator Shoot()
        {
            yield return new WaitForSeconds(Random.Range(0.3f, 0.8f));
            Vector3 Tọa_độ_viên_đạn = transform.position;
            Tọa_độ_viên_đạn.y -= 0.5f;
            Instantiate(bullet, Tọa_độ_viên_đạn, Quaternion.identity);
            StartCoroutine(Shoot());
        }
    }
}