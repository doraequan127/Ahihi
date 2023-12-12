using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace khoapham
{
    public class Nguoi_choi : MonoBehaviour
    {
        public Rigidbody2D rigidbody2D_;
        public Animator animator;
        public bool is_Sang_phải, is_Sang_trái;   //Dùng để liên lạc với Joystick.cs

        private float maxVelocity = 4;

        private void Awake()
        {
            //rigidbody2D_ = GetComponent<Rigidbody2D>();   //Dòng này có thể thay cho việc kéo thả GameObject "Nguoi_choi" vào ô "rigidbody2D_" trong mục script của chính GameObject "Nguoi_choi"
            //animator = GetComponent<Animator>();
        }

        private void FixedUpdate()    //FixedUpdate() dùng cho game có physics, còn Update() dùng cho game bình thường
        {
            float vel = Mathf.Abs(rigidbody2D_.velocity.x);
            if (vel < maxVelocity)     //Phải có lệnh if này để vận tốc nhân vật ko bị cộng dồn lên đến vô hạn (vì nếu ấn di chuyển liên tục thì vận tốc nhân vật sẽ tăng dần lên đến vô hạn)
            {
                if (Input.GetKey(KeyCode.RightArrow) || is_Sang_phải == true)
                {
                    animator.SetBool("is_Walk", true);    //is_Walk chính là parameter kiểu Bool ta tạo trong Animator
                    Vector3 leuleu = transform.localScale;   //3 dòng này giúp nhân vật quay sang phải khi đi sang phải
                    leuleu.x = Mathf.Abs(leuleu.x);
                    transform.localScale = leuleu;
                    rigidbody2D_.AddForce(new Vector2(400, 0));
                }
                else if (Input.GetKey(KeyCode.LeftArrow) || is_Sang_trái == true)
                {
                    animator.SetBool("is_Walk", true);
                    Vector3 leuleu = transform.localScale;   //3 dòng này giúp nhân vật quay sang trái khi đi sang trái
                    leuleu.x = -Mathf.Abs(leuleu.x);
                    transform.localScale = leuleu;
                    rigidbody2D_.AddForce(new Vector2(-400, 0));
                }
                else if (Input.GetKey(KeyCode.UpArrow)) rigidbody2D_.AddForce(new Vector2(0, 70));
                else animator.SetBool("is_Walk", false);
            }
        }

        public void button_Menu()
        {
            SceneManager.LoadScene(0);
        }
    }
}