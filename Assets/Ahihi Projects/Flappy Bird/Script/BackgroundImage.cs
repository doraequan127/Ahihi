using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class BackgroundImage : MonoBehaviour
    {
        private void Awake()
        {
            float tỉ_lệ = Camera.main.orthographicSize * 2 / GetComponent<SpriteRenderer>().bounds.size.y;
            transform.localScale = new Vector3(tỉ_lệ, tỉ_lệ);    //Phóng ảnh lên cho vừa camera
        }
    }
}