using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    private Quan_ly_cac_ham Quản_lý_các_hàm;
    private Rigidbody2D rigidbody2D_;
    private Animator animator;
    private float góc = 0, speed_xoay = 0;

    private void Awake()
    {
        rigidbody2D_ = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Quản_lý_các_hàm = GameObject.Find("Quan_ly_cac_ham").GetComponent<Quan_ly_cac_ham>();
    }

    private void Update()
    {
        //speed_xoay += 0.08f;
        //góc += speed_xoay;
        //transform.Rotate(0, 0, -speed_xoay);
        if (Input.GetMouseButtonDown(0) && !Quản_lý_các_hàm.is_Died)
        {
            rigidbody2D_.velocity = new Vector2(rigidbody2D_.velocity.x, 8);
            Quản_lý_các_hàm.playSound_Fly();
            //transform.Rotate(0, 0, góc + 30);
            //góc = -30;
            //speed_xoay = 0;
        }
        if (Input.GetKey(KeyCode.S))
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.name == "Score Space")
        {
            Quản_lý_các_hàm.eatScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" && !Quản_lý_các_hàm.is_Died)
        {
            Quản_lý_các_hàm.GameOver();
            animator.SetTrigger("Died");
        }
    }

    public void button_Fly()
    {
        //rigidbody2D_.velocity = new Vector2(rigidbody2D_.velocity.x, 8);
        //Quản_lý_các_hàm.playSound_Fly();
    }
}
