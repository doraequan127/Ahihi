using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuayLui : MonoBehaviour
{
    //Tìm tất cả các nhóm số có tổng bằng 12

    [Serializable]
    public struct battle1337
    {
        public List<int> result;
    }

    public List<int> dovbyk; //Ví dụ là 8,6,7,5,3,10,9,66,2,324,1,20
    public int targetSum; //Ví dụ là 12
    public List<battle1337> result; //Kết quả sẽ in vào đây
    Stack<int> girona = new Stack<int>();

    void findSum(List<int> dovbyk_, int targetSum_, int index)
    {
        if (targetSum_ < 0 || index == dovbyk_.Count) return;
        if (targetSum_ == 0)
        {
            result.Add(new battle1337() { result = girona.ToList() });
            return;
        }

        girona.Push(dovbyk_[index]);
        findSum(dovbyk_, targetSum_ - dovbyk_[index], index + 1);
        girona.Pop();

        findSum(dovbyk_, targetSum_, index + 1);
    }
}
