using System.Collections;
using UnityEngine;
using Templete;

public class Hello
{
    public static void Run()
    {
        Debug.Log("Hello, World");

        GameObject go = new GameObject("Test1");
        go.AddComponent<Print>();
        FGUIManager.Instance().Init();
        AssetLoader.Instance().LoadSceneAsync("Assets/Res/Entity/Scene/Test/Test.unity", (scene) =>
        {
             Debug.Log($"load {scene.Result.Scene.name}");
        });
    }
}