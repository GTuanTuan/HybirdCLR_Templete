using UnityEngine;
using UnityEditor;
using UnityEditor.AddressableAssets.Build;
//允许在 Unity 加载时初始化编辑器类，无需用户操作。
[InitializeOnLoad]
public static class PlayerModeEvent
{

	//初始化类时,注册事件处理函数
	static PlayerModeEvent()
	{
		EditorApplication.playModeStateChanged += OnPlayerModeStateChanged;
		BuildScript.buildCompleted += OnBuildCompleted;
	}
	private static void OnBuildCompleted(AddressableAssetBuildResult result)
    {
		Debug.Log("custom build event");
    }
	private static void OnPlayerModeStateChanged(PlayModeStateChange playModeState)
	{
		if(playModeState == PlayModeStateChange.ExitingEditMode)
        {
			Templete.CopyHotDll.CopyDll2Byte();
		}
		Debug.LogFormat("state:{0} will:{1} isPlaying:{2}", playModeState, EditorApplication.isPlayingOrWillChangePlaymode, EditorApplication.isPlaying);
	}
	//当点"Play"按钮进入播放模式时
	//输出：
	//state:ExitingEditMode will:True isPlaying:False
	//state:EnteredPlayMode will:True isPlaying:True
}