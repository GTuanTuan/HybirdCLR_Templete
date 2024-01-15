using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Templete;

public class GameStart : MonoBehaviour
{
    public static void Run()
    {
        GameObject panel = GameObject.Find("PreloadPanel");
        FGUIManager.Instance().Init();
        AssetLoader.Instance().LoadSceneAsync("Assets/Res/Entity/Scene/Test/Test.unity", (scene) =>
        {
            Debug.Log($"load {scene.Result.Scene.name}");
            panel.GetComponent<PreloadPanel>().SetVisible(false);
        });
    }
}
