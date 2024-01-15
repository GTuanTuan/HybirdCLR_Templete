using System.Collections;
using System.Collections.Generic;
using Templete;
using UnityEngine;

public class Print : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"[Print] GameObject:{name}");
        GameObject panel = GameObject.Find("PreloadPanel");
        FGUIManager.Instance().Init();
        AssetLoader.Instance().LoadSceneAsync("Assets/Res/Entity/Scene/Test/Test.unity", (scene) =>
        {
            Debug.Log($"load {scene.Result.Scene.name}");
            panel.GetComponent<PreloadPanel>().SetVisible(false);
        });
    }
}