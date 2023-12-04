using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PremierLeague
{
    public string name;
    public List<Club> clubsList;
}

[Serializable]
public struct Club
{
    public string name;
    public int age;
    public List<Player> playersList;
}

[Serializable]
public struct Player
{
    public string name;
    public int number;
}

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


    private void Start()
    {
        
    }

    public void Update()
    {
        
    }
}