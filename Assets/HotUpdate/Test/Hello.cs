using System.Collections;
using UnityEngine;
using Templete;

public class Hello
{
    public static void Run()
    {
        TestDebug.Log("Hello, World");
        GameObject go = new GameObject("Test1");
        go.AddComponent<Print>();
    }
}