using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class BackgroundQuad : MonoBehaviour
    {
        private float speed = 0.2f;
        private Vector2 vector2;

        private void Awake()
        {
            //float Chiều_cao = Camera.main.orthographicSize * 2;
            //float Chiều_rộng = Chiều_cao * Screen.width / Screen.height;  //6.024096f
            //print(Chiều_cao + "  " + Chiều_rộng);
            transform.localScale = new Vector3(6.024096f, 10, 0);    //Chỉnh width, height của BackgroundQuad cho nó vừa màn hình camera

            vector2 = GetComponent<Renderer>().material.GetTextureOffset("_MainTex");
        }

        private void Update()
        {
            vector2.y += speed * Time.deltaTime;
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", vector2);
        }
    }
}