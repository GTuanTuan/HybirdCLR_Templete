using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using System.Text;
using UnityEngine.AddressableAssets;

namespace Templete
{
    public class FGUIManager : SingleBase<FGUIManager>
    {
        static FGUISetting setting;
        bool ready;
        public bool Ready
        {
            get
            {
                return ready;
            }
        }
        //-1未加载
        //0加载中
        //1加载完
        public static Dictionary<string, int> add_map = new Dictionary<string, int>();
        public void Init()
        {
            FGUISetting.Instance((_setting) => { setting = _setting; });
            CheckTick.AddRule(
                () =>
                {
                    return FGUISetting.Ready;
                },
                () =>
                {
                    ConfigUIContentScaler();
                    InitUIFonts();
                    CreateLayer();
                    ready = true;
                    return true;
                }
            );

        }
        private void ConfigUIContentScaler()
        {
            Stage stage = Stage.inst;
            UIContentScaler scaler = stage.gameObject.GetComponent<UIContentScaler>();
            if (scaler != null)
            {
                if (setting.scaleWithDefaultResolution)
                {
                    scaler.scaleMode = UIContentScaler.ScaleMode.ScaleWithScreenSize;
                    scaler.designResolutionX = setting.defaultResolution.x;
                    scaler.designResolutionY = setting.defaultResolution.y;
                }
                else
                {
                    scaler.scaleMode = UIContentScaler.ScaleMode.ConstantPixelSize;
                    scaler.constantScaleFactor = 1;
                }
                scaler.ApplyChange();
                GRoot.inst.ApplyContentScaleFactor();
            }
        }

        private void InitUIFonts()
        {
            if (string.IsNullOrWhiteSpace(UIConfig.defaultFont)
                && setting.fonts != null
                && setting.fonts.Length > 0)
            {
                StringBuilder fontsStr = new StringBuilder();
                for (int i = 0; i < setting.fonts.Length; i++)
                {
                    Font font = setting.fonts[i];
                    for (int j = 0; j < font.fontNames.Length; j++)
                    {
                        string fontName = font.fontNames[j];
                        FontManager.RegisterFont(new DynamicFont(fontName, font), fontName);
                        fontsStr.Append(fontName);
                        fontsStr.Append(",");
                    }
                }
                fontsStr.Remove(fontsStr.Length - 1, 1);
                string defaultFonts = fontsStr.ToString();
                UIConfig.defaultFont = defaultFonts;
                Debug.Log("Default fonts: " + defaultFonts);
            }
        }

        private void CreateLayer()
        {
            foreach (string layer in setting.UILayers)
            {
                GComponent com = new GComponent();
                com.gameObjectName = layer;
                com.name = layer;
                com.fairyBatching = true;
                GRoot.inst.AddChild(com);
            }
        }

        private static readonly UIPackage.LoadResource loadResource = (string key, string extension, Type type, out DestroyMethod destroyMethod) =>
        {
            destroyMethod = DestroyMethod.None;
            return LoadPackage(key, extension);
        };

        private static object LoadPackage(string key, string extension)
        {
            if (key.Contains("!a"))
            {
                return null;
            }
            object res = Addressables.LoadAssetAsync<object>(key + extension).WaitForCompletion();
            if (res == null)
            {
                Debug.LogError($"FGUI加载{key}{extension}失败");
            }
            return res;
        }
        private static void LoadPackageAsync(string pkgName, string name, string extension,PackageItem item,DestroyMethod destroyMethod)
        {
            if (name.Contains("!a"))
            {
                return;
            }
            Addressables.LoadAssetAsync<object>(setting.AddressableKeyFormat+"/"+ pkgName +"/"+ name + extension).Completed += (_handle) =>
            {
                object res = _handle.Result;
                if (res == null)
                {
                    Debug.LogError($"FGUI加载{name}{extension}失败");
                }
                item.owner.SetItemAsset(item, res, destroyMethod);
            };
        }
        public int CheckAdd(string pkgName)
        {
            if (!add_map.ContainsKey(pkgName))
            {
                add_map.Add(pkgName, -1);
            }
            return add_map[pkgName];
        }
        public void AddPackage(string pkgName, bool async=false)
        {
            string key = FGUISetting.GetKeyByPkgName(pkgName);
            if (CheckAdd(pkgName)==-1)
            {
                add_map[pkgName] = 0;
                if (!async)
                {
                    UIPackage.AddPackage(key, loadResource);
                    add_map[pkgName] = 1;
                }
                else
                {
                    Addressables.LoadAssetAsync< TextAsset>(key + "_fui.bytes").Completed += (_handle) =>
                    {
                        byte[] descData = (_handle.Result as TextAsset).bytes;
                        UIPackage.AddPackage(descData, pkgName, (string name, string extension, Type type, PackageItem item) =>
                        {
                            LoadPackageAsync(pkgName,name, extension, item, DestroyMethod.None);
                        });
                        add_map[pkgName] = 1;
                    };
                }
            }
        }
    }
}
