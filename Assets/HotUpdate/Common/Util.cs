using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Templete;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class Util : SingleBase<Util>
{
    public string GetKey(string key)
    {
        key = key.Replace("\\", "/").Replace("//", "/");
        return key;
    }
    //public void LoadAssetsAsync(List<AssetSetting> settings, string title,Action<List<object>> allCompleted = null)
    //{
    //    List<object> handles = new List<object>();
    //    LoadingPanel.Instance().Open((loading)=> {
    //        loading.bar.value = 0;
    //        loading.title.text = title;
    //        foreach (AssetSetting setting in settings)
    //        {
    //            if(setting.AssetType == AssetType.Scene)
    //            {
    //                handles.Add(AssetLoader.Instance().LoadSceneAsync(setting.Key));
    //            }
    //            else
    //            {
    //                handles.Add(AssetLoader.Instance().LoadAssetAsync(setting.Key));
    //            }
    //        }
    //        OnLoad(settings, handles, allCompleted);
    //    });
    //}
    //void OnLoad(List<AssetSetting> settings, List<object> handles, Action<List<object>> allCompleted =null)
    //{
    //    CheckTick.AddRule(
    //        () => {
    //            bool loadAll = true;
    //            float progress = 0;
    //            for (int i = 0; i < settings.Count; i++)
    //            {
    //                AsyncOperationHandle asyncOperation = settings[i].AssetType == AssetType.Prefab? 
    //                (handles[i] as AssetHandle).asyncOperationHandle: (handles[i] as SceneHandle<SceneInstance>).asyncOperationHandle;
    //                progress += asyncOperation.PercentComplete;
    //                if (asyncOperation.IsDone)
    //                {
    //                    if (!settings[i].isDone)
    //                    {
    //                        settings[i].isDone = true;
    //                        settings[i].Completed?.Invoke(handles[i]);
    //                    }
    //                }
    //                else
    //                {
    //                    loadAll = false;
    //                }
    //            }
    //            LoadingPanel.Instance().bar.value = Mathf.Lerp((float)LoadingPanel.Instance().bar.value, (progress / handles.Count) * 100,Time.deltaTime*2);
    //            TestDebug.Log("bar" + LoadingPanel.Instance().bar.value + "progress"+ progress);
    //            return loadAll;
    //        },
    //        () => {
    //            LoadingPanel.Instance().Close();
    //            allCompleted?.Invoke(handles);
    //            return true;
    //        }
    //    );
    //}
}
public enum AssetType
{
    Scene=1,
    Prefab=2
}
public class AssetSetting
{
    public string Key;
    public AssetType AssetType = AssetType.Prefab;
    public Action<object> Completed;
    public bool isDone;
}
