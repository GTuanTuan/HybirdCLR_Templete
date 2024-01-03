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
            string sourcePath = $"{Application.dataPath.Replace("/Assets","")}/HybridCLRData/HotUpdateDlls/StandaloneWindows64/HotUpdate.dll";
            string destPath = $"{Application.dataPath}/Res/HotUpdate/HotUpdate.dll.bytes";
            if (File.Exists(destPath))
            {
                File.Delete(destPath);
            }
            File.Copy(sourcePath, destPath);
            AssetDatabase.Refresh();
            Debug.Log("copy over");
        }
    }
}