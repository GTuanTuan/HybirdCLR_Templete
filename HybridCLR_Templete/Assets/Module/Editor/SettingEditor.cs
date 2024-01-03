using UnityEditor;
using UnityEngine;
using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEditor.AddressableAssets.Settings;

namespace Templete
{
    public class SettingEditor
    {
        public static string[] settings = new string[]
        {
            //"LuaSetting",
            "FGUISetting",
            //"SqlConfig"
        };
        [MenuItem("Tools/SettingAddress")]
        public static void Set()
        {
            foreach (string setting in settings)
            {
                CheckSetting(setting);
            }
        }

        public static void CheckSetting(string setting)
        {
            string[] ids = AssetDatabase.FindAssets($"t:{setting}");
            string assetGUID;
            if (ids.Length > 0)
            {
                assetGUID = ids[0];
            }
            else
            {
                //string path = Application.dataPath;
                //string assetPath = System.IO.Path.Combine(path, $"{setting}.asset");
                //var obj = Assembly.Load("Templete").CreateInstance(setting) as UnityEngine.Object;
                //AssetDatabase.CreateAsset(obj, assetPath);
                //AssetDatabase.SaveAssets();
                //ids = AssetDatabase.FindAssets($"t:{setting}");
                //assetGUID = ids[0];
                Debug.LogError($"Î´ÕÒµ½{setting}.asset");
                return;
            }
            string[] settingsIDs = AssetDatabase.FindAssets("t:AddressableAssetSettings");
            if (settingsIDs.Length > 0)
            {
                string settingsPath = AssetDatabase.GUIDToAssetPath(settingsIDs[0]);
                AddressableAssetSettings settings = AssetDatabase.LoadAssetAtPath<AddressableAssetSettings>(settingsPath);
                AddressableAssetGroup group = settings.FindGroup("Settings");
                if (group == null)
                {
                    group = settings.CreateGroup("Settings", false, false, true, null);
                }
                AddressableAssetEntry entry = settings.CreateOrMoveEntry(assetGUID, group);
                entry.SetAddress($"Settings/{setting}.asset");
                entry.SetLabel("Settings", true, true);
            }
            else
            {
                throw new System.IO.FileNotFoundException("AddressableAssetSettings.asset not exists");
            }
        }
    }
}