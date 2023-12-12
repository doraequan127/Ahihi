using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace khoapham
{
    public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        //Hàm bắt sự kiện nhấn thả button này chỉ áp dụng cho các Button có add cái script này

        public Nguoi_choi nguoi_Choi;    //Dùng để liên lạc với Nguoi_choi.cs

        private void Awake()
        {
            //nguoi_Choi = GameObject.Find("Nguoi choi").GetComponent<Nguoi_choi>();
        }

        public void OnPointerDown(PointerEventData pointerEventData)   //Hàm bắt sự kiện click nút Button
        {
            if (name == "Left") nguoi_Choi.is_Sang_trái = true;
            else if (name == "Right") nguoi_Choi.is_Sang_phải = true;
        }

        public void OnPointerUp(PointerEventData pointerEventData)   //Hàm bắt sự kiện nhả nút Button
        {
            if (name == "Left") nguoi_Choi.is_Sang_trái = false;
            else if (name == "Right") nguoi_Choi.is_Sang_phải = false;
        }
    }
}