using System.Collections;
using System.Collections.Generic;
using Templete;
using UnityEngine;

public class Print : MonoBehaviour
{
    void Start()
    {
        TestDebug.Log($"[Print] GameObject:{name}");
        //GameObject panel = GameObject.Find("PreloadPanel");
        //FGUIManager.Instance().Init();
        //AssetLoader.Instance().LoadSceneAsync("Assets/Res/Entity/Scene/Test/Test.unity", (scene) =>
        //{
        //    TestDebug.Log($"load {scene.Result.Scene.name}");
        //    panel.GetComponent<PreloadPanel>().SetVisible(false);
        //});
        gameObject.GetComponent<Print>().Init();
    }
    public void Init()
    {
        TestDebug.Log($"Init");
    }
}