using Cysharp.Threading.Tasks;
using DG.Tweening;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
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

    #region Chỉnh lại tên của enum trên Inspector
    //public enum ManUtd
    //{
    //    [InspectorName("Siêu sao số 1 thế giới")] ronaldo
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

    #region Event (có 2 cách là delegate của C# và UnityEvent của unity)
    ////Cách 1: delegate
    //delegate void a(int b, string c);
    //a songoku;
    //void RunDelegate()
    //{
    //    songoku += ditconme;
    //    songoku += muvodoi;
    //    songoku(5, "you never walk alone");
    //}

    ////Cách 2: UnityEvent (nên dùng)
    //public UnityEvent<int, string> b; //có thể serialize ra Inspector (cái này delegate ko làm được)
    //void RunUnityEvent()
    //{
    //    b = new UnityEvent<int, string>();
    //    b.AddListener(ditconme);
    //    b.AddListener(muvodoi);
    //    b.Invoke(3, "glory");
    //}

    //void ditconme(int g, string h)
    //{
    //    print("Dit cu chung may");
    //}

    //void muvodoi(int g, string h)
    //{
    //    print("mu vo doi");
    //}
    #endregion

    #region Thông tin về thiết bị
    void PrintDeviceInfo()
    {
        print("Device Name: " + SystemInfo.deviceName);
        print("Device Model: " + SystemInfo.deviceModel);
        print("Device Type: " + SystemInfo.deviceType);
        print("Batery Status: " + SystemInfo.batteryStatus);
        print("batteryLevel: " + SystemInfo.batteryLevel);
        print("Operating System: " + SystemInfo.operatingSystem);
        print("processorModel: " + SystemInfo.processorModel);
        print("processorType: " + SystemInfo.processorType);
        print("processorCount: " + SystemInfo.processorCount);
        print("processorFrequency: " + SystemInfo.processorFrequency);
        print("processorManufacturer: " + SystemInfo.processorManufacturer);
        print("systemMemorySize: " + SystemInfo.systemMemorySize);
        print("graphicsDeviceName: " + SystemInfo.graphicsDeviceName);
        print("graphicsDeviceType: " + SystemInfo.graphicsDeviceType);
        print("graphicsDeviceVendor: " + SystemInfo.graphicsDeviceVendor);
        print(Application.unityVersion);
        print(Application.version);
        print(Application.dataPath);
        print(Application.installerName); //Tên store hay package cài đặt cái game này
        print(Application.platform);
        print(Application.systemLanguage);
        //Handheld.Vibrate(); //Rung máy
    }
    #endregion

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void dcm()
    {
        print("1 cham la say dam");
    }
}