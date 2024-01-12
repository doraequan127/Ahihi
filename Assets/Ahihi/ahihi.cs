using DG.Tweening;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
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

    #region Cách thoát khỏi IEnumerator
    IEnumerator TestBreak()
    {
        print("ahihi");
        yield break; // Thoát khỏi TestBreak
        print("dcm");
    }
    #endregion

    #region Resources.Load bất đồng bộ
    IEnumerator LoadSomething()
    {
        ResourceRequest resourceRequest = Resources.LoadAsync<Sprite>("doraemon");
        while (!resourceRequest.isDone)
        {
            print("Chưa load xong, mới load được có " + resourceRequest.progress * 100 + "%");
            yield return null;
        }
        print("Đã load thành công, tên asset là :  " + resourceRequest.asset.name);
    }
    #endregion

    public AssetReference assetReference;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}