using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCustomEditor : MonoBehaviour
{
    public Vector3 testScale;
    public int garnacho;
    public Bayern bayern;
    [TextArea] public string mainoo;

    public void PrintSomething()
    {
        print("print ra cai j do");
    }
}

[Serializable]
public class Bayern
{
    public string tomasTuchel;
}