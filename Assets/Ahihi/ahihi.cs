using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class ahihi : MonoBehaviour
{
    #region Enum có thể chọn nhiều cái cùng 1 lúc

    //[Flags]
    //public enum ManUtd
    //{
    //    Eriksen = 1,
    //    Hojlund = 2,
    //    Mainoo = 4,
    //    Casemiro = 8,
    //    MID = Mainoo | Casemiro,
    //}

    //public ManUtd manUtd;

    //public void Chon2Cai1Luc(ManUtd manUtd1, ManUtd manUtd2)
    //{
    //    if (manUtd == (manUtd1 | manUtd2))
    //        print("Đang chọn " + manUtd1 + " và " + manUtd2 + " cùng 1 lúc.");
    //}

    #endregion

    #region Gizmos

    //Hiển thị Gizmos khi gameobject được selected
    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = new Color(1, 0, 0, 0.5f);
    //    //Gizmos.DrawCube(transform.position, new Vector3(10, 10, 10));
    //    Gizmos.DrawRay(transform.position, Vector3.right * 100);
    //}

    //Luôn luôn hiển thị Gizmos
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(1, 0, 0, 0.5f);
    //    Gizmos.DrawCube(transform.position, new Vector3(10, 10, 10));
    //}

    #endregion

    #region Hiển thị ra 1 nút trong dấu 3 chấm ở góc trên phải component Ahihi, nó sẽ thực thi hàm này

    // Tương đối giống [MenuItem] nhưng khác biệt ở chỗ [MenuItem] chỉ chạy đc hàm static, còn [ContextMenu] chạy đc hàm private

    //[ContextMenu("Hát bài quốc ca của Manchester United")]
    //void GloryGlory()
    //{
    //    print("Glory Glory Man United !");
    //}

    #endregion

    ResourceRequest load;
    public Sprite oa;

    private void Start()
    {
        //load = Resources.LoadAsync<Sprite>("3");
        //oa = Resources.Load<Sprite>("4");

        //StartCoroutine(LoadSomething());

        TestBatDongBo();
    }

    IEnumerator LoadSomething()
    {
        load = Resources.LoadAsync<Sprite>("4");
        while (!load.isDone)
        {
            print("Chua load xong" + load.progress);
            yield return null;
        }
        print("Load thanh cong");
        oa = load.asset as Sprite;
        print(oa.name);
    }

    private void Update()
    {
        //print(load.progress + " " + load.isDone);
    }

    async Task TestBatDongBo()
    {
        //oa = await Resources.Load<Sprite>("4");
        print("Bat dau game");
        await Task.Delay(3000);
        //int t = await hojlund();
        print("Sau 3 giay");
    }

    async Task<int> hojlund()
    {
        return 3;
    }
}