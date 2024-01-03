using HybridCLR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Templete
{
    public class LoadDll : MonoBehaviour
    {
        public string HotDllKey;
        void Start()
        {
            AssetHandle assetHandle = AssetLoader.Instance().LoadAssetAsync(HotDllKey);
            assetHandle.asyncOperationHandle.Completed+=((handle) =>
            {
                Assembly hotUpdateAss = Assembly.Load((handle.Result as TextAsset).bytes);
                Type type = hotUpdateAss.GetType("Hello");
                type.GetMethod("Run").Invoke(null, null);
                //#if !UNITY_EDITOR
                //                Assembly hotUpdateAss = Assembly.Load((handle.Result as TextAsset).bytes);
                //#else
                //                // Editor下无需加载，直接查找获得HotUpdate程序集
                //                Assembly hotUpdateAss = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "HotUpdate");
                //#endif
            });



        }

    }
}

