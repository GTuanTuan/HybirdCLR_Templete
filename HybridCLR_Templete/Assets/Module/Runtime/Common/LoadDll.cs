using HybridCLR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Templete
{
    public enum DllType
    {
        T,
        Hot
    }
    public class LoadDll : MonoBehaviour
    {
        public Dictionary<string, DllType> dllMap = new Dictionary<string, DllType>()
        {
            { "mscorlib",DllType.T },
            { "System",DllType.T },
            { "System.Core",DllType.T },
            { "HotUpdate",DllType.Hot },
        };
        void Start()
        {
            foreach (KeyValuePair<string, DllType> dll in dllMap)
            {
                Addressables.LoadAssetAsync<TextAsset>(dll.Key).Completed += (AsyncOperationHandle<TextAsset> handle) =>
                {
                    if (dll.Value == DllType.T)
                    {
                        RuntimeApi.LoadMetadataForAOTAssembly((handle.Result as TextAsset).bytes, HomologousImageMode.SuperSet);
                    }
                    else
                    {
#if !UNITY_EDITOR
                        Assembly hotUpdateAss = Assembly.Load((handle.Result as TextAsset).bytes);
#else
                        Assembly hotUpdateAss = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "HotUpdate");
#endif
                        Type type = hotUpdateAss.GetType("GameStart");
                        type.GetMethod("Run").Invoke(null, null);
                    }
                };
            }
        }
    }
}

