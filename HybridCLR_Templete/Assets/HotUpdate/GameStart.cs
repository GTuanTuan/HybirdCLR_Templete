using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Templete;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GameStart : MonoBehaviour
{
    public static void Run()
    {
        FGUIManager.Instance().Init();
        //preload loadingpanel
        AsyncOperationHandle asyncOperation = Addressables.LoadAssetAsync<TextAsset>("Assets/Res/UI/Yango/Yango_fui.bytes");
        asyncOperation.Completed += (handle) =>
        {
            TestDebug.Log($"load {handle.Result}");
        };
        CheckTick.AddRule(
            () =>{ return FGUIManager.Instance().Ready&& asyncOperation.IsDone; },
            () =>{LoadSceneTest();return true;}
        );
        GameObject go = new GameObject("Test1");
        go.AddComponent<Print>();
    }
    public static void LoadSceneTest()
    {
        AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync("Assets/Res/Entity/Scene/Test/Test.unity",LoadSceneMode.Additive);
        LoadingPanelCtrl.Inst.Open(handle, $"Loading Test");
        handle.Completed += (obj) =>
        {
            TestDebug.Log("Test");
        };
    }
}
