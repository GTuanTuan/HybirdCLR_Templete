using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Templete
{
    public enum AssetType
    {
        GameObject=0,
    }
    public class AssetLoader : SingleBase<AssetLoader>
    {
        private static Dictionary<string, AssetHandle> assetMap = new Dictionary<string, AssetHandle>();
        private static Dictionary<string, SceneHandle<SceneInstance>> sceneMap = new Dictionary<string, SceneHandle<SceneInstance>>();

        string GetKey(string key)
        {
            key = key.Replace("\\", "/").Replace("//", "/");
            return key;
        }
        public AssetHandle LoadAsset(string key)
        {
            return LoadAsset<object>(key);
        }
        public AssetHandle LoadAssetAsync(string key)
        {
            return LoadAssetAsync<object>(key);
        }
        //同步加载资源
        public AssetHandle LoadAsset<T>(string key)
        {
            key = GetKey(key);
            if (assetMap.ContainsKey(key))
            {
                return assetMap[key];
            }
            AssetHandle assetLoaderHandle = CreateAssetData<T>(key);
            assetLoaderHandle.assetData.asset = assetLoaderHandle.asyncOperationHandle.WaitForCompletion();
            return assetLoaderHandle;
        }

        //异步加载资源
        public AssetHandle LoadAssetAsync<T>(string key)
        {
            key = GetKey(key);
            if (assetMap.ContainsKey(key))
            {
                return assetMap[key];
            }
            return CreateAssetData<T>(key);
        }
        //异步加载场景
        public SceneHandle<SceneInstance> LoadSceneAsync(string key,Action<AsyncOperationHandle<SceneInstance>> completed=null, LoadSceneMode loadMode = LoadSceneMode.Additive, bool activateOnLoad = true, int priority = 100)
        {
            key = GetKey(key);
            if (sceneMap.ContainsKey(key))
            {
                return sceneMap[key];
            }
            SceneHandle<SceneInstance> assetLoaderHandle = new SceneHandle<SceneInstance>();
            assetLoaderHandle.asyncOperationHandle = Addressables.LoadSceneAsync(key, loadMode, activateOnLoad, priority);
            assetLoaderHandle.assetData.key = key;
            assetLoaderHandle.asyncOperationHandle.Completed += (Scene) =>
            {
                //Scene.Result.ActivateAsync();
                SceneManager.SetActiveScene(Scene.Result.Scene);
                completed?.Invoke(Scene);
            };
            return assetLoaderHandle;
        }
        public static AssetHandle CreateAssetData<T>(string key)
        {
            AssetHandle assetLoaderHandle = new AssetHandle();
            assetLoaderHandle.asyncOperationHandle = Addressables.LoadAssetAsync<T>(key);
            assetLoaderHandle.assetData.key = key;
            assetMap[key] = assetLoaderHandle;
            return assetLoaderHandle;
        }
    }
    public class AssetData
    {
        public string key;
        public object asset;
    }
    public class AssetHandle
    {
        public AsyncOperationHandle asyncOperationHandle;
        public AssetData assetData=new AssetData();
        public void AddCallback(Action<AsyncOperationHandle> action)
        {
            asyncOperationHandle.Completed += action;
        }
    }
    public class SceneHandle<SceneInstance>
    {
        public AsyncOperationHandle<SceneInstance> asyncOperationHandle;
        public AssetData assetData= new AssetData();
    }
}
