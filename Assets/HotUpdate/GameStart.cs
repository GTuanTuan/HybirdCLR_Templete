using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Templete;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

public class GameStart : MonoBehaviour
{
    public static void Run()
    {
        FGUIManager.Instance.Init();
        //preload loadingpanel
        AsyncOperationHandle asyncOperation = Addressables.LoadAssetAsync<TextAsset>("Assets/Res/UI/Yango/Yango_fui.bytes");
        asyncOperation.Completed += (handle) =>
        {
            TestDebug.Log($"load {handle.Result}");
        };
        CheckTick.AddRule(
            () =>{ return FGUIManager.Instance.Ready&& asyncOperation.IsDone; },
            () =>{ LoadSceneTest();return true;}
        );
        GameObject go = new GameObject("Test1");
        go.AddComponent<Print>();
    }
    public static void LoadArisRunTest()
    {
        Camera.main.transform.position = new Vector3(137, 12, 122);
        Action<AsyncOperationHandle> callback = (handle) =>
        {
            GameObject.Instantiate(handle.Result as GameObject);
        };
        List<AsyncOperationHandle> handles = new List<AsyncOperationHandle>();
        AsyncOperationHandle natureHandle = Addressables.LoadAssetAsync<GameObject>("Assets/Res/Entity/Prefab/Nature/Nature.prefab");
        AsyncOperationHandle buildingsHandle = Addressables.LoadAssetAsync<GameObject>("Assets/Res/Entity/Prefab/Buildings/Buildings.prefab");
        AsyncOperationHandle envHandle = Addressables.LoadAssetAsync<GameObject>("Assets/Res/Entity/Prefab/Evn/Environment.prefab");
        AsyncOperationHandle playerHandle = Addressables.LoadAssetAsync<GameObject>("Assets/Res/Entity/Prefab/Player/Player.prefab");
        handles.Add(natureHandle);
        handles.Add(buildingsHandle);
        handles.Add(envHandle);
        handles.Add(playerHandle);
        LoadingPanelCtrl.Inst.Open(handles, $"Loading ArisRunTest");
        natureHandle.Completed += callback;
        buildingsHandle.Completed += callback;
        envHandle.Completed += callback;
        CheckTick.AddRule(
            () => { return natureHandle.IsDone && buildingsHandle.IsDone && envHandle.IsDone && playerHandle.IsDone; },
            () => {
                GameObject.Instantiate(playerHandle.Result as GameObject, new Vector3(137, 12, 122), Quaternion.identity);
                return true;
            }
        );
    }
    public static void LoadSceneTest()
    {
        AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync("Assets/Res/Entity/Scene/Test/Test.unity",LoadSceneMode.Additive);
        LoadingPanelCtrl.Inst.Open(handle, $"Loading Test");
        handle.Completed += (sceneHandle) =>
        {
            SceneManager.SetActiveScene(sceneHandle.Result.Scene);
            TestDebug.Log("Test");
        };
    }
}
