using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Text;

namespace Templete
{
    public class CopyHotDll 
    {
        [MenuItem("Tools/CopyHotDll")]
        public static void CopyDll2Byte()
        {
            HybridCLR.Editor.Commands.CompileDllCommand.CompileDllActiveBuildTarget();
            //StandaloneWindows64
            //string sourcePath = $"{Application.dataPath.Replace("/Assets","")}/HybridCLRData/HotUpdateDlls/StandaloneWindows64/HotUpdate.dll";
            //WebGL
            string sourcePath = $"{Application.dataPath.Replace("/Assets", "")}/HybridCLRData/HotUpdateDlls/WebGL/HotUpdate.dll";

            string destPath = $"{Application.dataPath}/Res/HotUpdate/HotUpdate.dll.bytes";
            if (File.Exists(destPath))
            {
                File.Delete(destPath);
            }
            File.Copy(sourcePath, destPath);
            AssetDatabase.Refresh();
            Debug.Log("copy over");
        }
        [MenuItem("Tools/Copy<T>Dll")]
        public static void CopyTDll2Byte()
        {
            HybridCLR.Editor.Commands.CompileDllCommand.CompileDllActiveBuildTarget();
            string sourceDir = $"{Application.dataPath.Replace("/Assets", "")}/HybridCLRData/AssembliesPostIl2CppStrip/WebGL/";
            string destDir = $"{Application.dataPath}/Res/T/";
            List<string> DllList = new List<string>()
            {
                "mscorlib.dll",
                "System.dll",
                "System.Core.dll",
            };
            foreach (string dll in DllList)
            {
                string sourcePath = sourceDir + dll;
                string destPath = destDir + dll + ".bytes";
                if (File.Exists(destPath))
                {
                    File.Delete(destPath);
                }
                File.Copy(sourcePath, destPath);
            }
            AssetDatabase.Refresh();
            Debug.Log("copy over");
        }
    }
}