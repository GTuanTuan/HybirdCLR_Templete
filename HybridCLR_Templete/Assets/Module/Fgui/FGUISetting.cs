using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Templete
{
    public class FGUISetting : ScriptableObject
    {
        public string AddressableKeyFormat = "Assets/Res/ui/";

        public Font[] fonts;

        public Vector2Int defaultResolution = new Vector2Int(1920, 1080);

        public bool scaleWithDefaultResolution = true;

        public bool autoMakeFullScreen = true;

        public string[] UILayers;
        protected FGUISetting() { }
        ~FGUISetting() { setting = null; }
        private static FGUISetting setting;
        private static readonly object locker = new object();
        private static bool ready = false;
        public static void Instance(Action<FGUISetting> callback = null)
        {
            if (setting == null && ready == false)
            {
                lock (locker)
                {
                    if (setting == null && ready == false)
                    {
                        AssetHandle assetHandle = AssetLoader.Instance().LoadAssetAsync<FGUISetting>("Settings/FGUISetting.asset");
                        assetHandle.asyncOperationHandle.Completed += (handle) =>
                        {
                            setting = (FGUISetting)handle.Result;
                            callback?.Invoke(setting);
                            ready = true;
                        };
                    }
                }
            }
        }
        public static bool Ready
        {
            get
            {
                return ready;
            }
        }
        public static string GetKeyByPkgName(string pkgName)
        {
            return setting.AddressableKeyFormat +"/"+ pkgName.ToLower() + "/" + pkgName;
        }
        public static string GetPkgNameByKey(string key)
        {
            string[] str_list = key.Split('/');
            return str_list[str_list.Length - 1];
        }
    }
}