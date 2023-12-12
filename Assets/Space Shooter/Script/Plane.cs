using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class Plane : MonoBehaviour
    {
        public GameObject bullet;
        public GameObject Explode;

        private Rigidbody2D rigidbody2D_;
        private Quan_ly_cac_ham Quản_lý_các_hàm;
        private float xmax, xmin, ymax, ymin;
        private bool Được_phép_bắn = true;

        private void Awake()
        {
            Quản_lý_các_hàm = GameObject.Find("Quan_ly_cac_ham").GetComponent<Quan_ly_cac_ham>();
            rigidbody2D_ = GetComponent<Rigidbody2D>();
            //xmax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x - 0.2f;   //2.812048f
            xmax = 2.712048f;
            xmin = -xmax;
            //ymax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1)).y;
            ymax = 5;
            ymin = -ymax;
        }

        private void Update()
        {
            float speed = 4f * Time.deltaTime;
            float speed_x = Input.GetAxisRaw("Horizontal") * speed;
            float speed_y = Input.GetAxisRaw("Vertical") * speed;

            //Cách 1: (cách này đỡ bị giật nhất)
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + speed_x, xmin, xmax), Mathf.Clamp(transform.position.y + speed_y, ymin, ymax));

            //Cách 2:
            //transform.Translate(speed_x, speed_y);

            //Cách 3:
            //transform.position = Vector3.MoveTowards(điểm đầu, điểm cuối, speed);    //Dùng cách này chỉ để di chuyển tự động, ko thể điều khiển được

            //Cách 4:
            //rigidbody2D_.velocity = new Vector2(speed_x, speed_y);    //Theo như Unity Document khuyên bảo thì ko nên dùng cái này, thay vào đó ta nên dùng cách 5
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, xmin, xmax), Mathf.Clamp(transform.position.y, ymin, ymax));    //Giới hạn position cho máy bay ko bay ra ngoài màn hình

            //Cách 5:
            //rigidbody2D_.AddForce(new Vector2(speed_x, speed_y));   //Nếu thích có quán tính thì dùng lệnh này
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, xmin, xmax), Mathf.Clamp(transform.position.y, ymin, ymax));    //Giới hạn position cho máy bay ko bay ra ngoài màn hình

            //if (Input.GetKeyDown(KeyCode.Space))
            //    Instantiate(bullet, transform.position, Quaternion.identity);

            if (Input.GetKey(KeyCode.Space))
                if (Được_phép_bắn) StartCoroutine(Shoot());
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.name == "RockBig(Clone)" || collider2D.name == "RockSmall(Clone)" || collider2D.name == "Enemy(Clone)")
            {
                Destroy(gameObject);
                Destroy(collider2D.gameObject);
                Instantiate(Explode, transform.position, Quaternion.identity);
                Instantiate(Explode, collider2D.transform.position, Quaternion.identity);
                Quản_lý_các_hàm.playSound_Explode();
                Quản_lý_các_hàm.Gọi_PanelGameOver();
            }
            if (collider2D.name == "RedBullet(Clone)")
            {
                Destroy(collider2D.gameObject);
                Destroy(gameObject);
                Quản_lý_các_hàm.playSound_Explode();
                Instantiate(Explode, transform.position, Quaternion.identity);
                Quản_lý_các_hàm.Gọi_PanelGameOver();
            }
        }

        IEnumerator Shoot()
        {
            Được_phép_bắn = false;
            Vector3 Tọa_độ_viên_đạn = transform.position;
            Tọa_độ_viên_đạn.y += 0.5f;      //cộng lên để cho đạn bắn ra từ mũi máy bay chứ ko phải tâm máy bay
            Instantiate(bullet, Tọa_độ_viên_đạn, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
            Được_phép_bắn = true;
        }
    }
}