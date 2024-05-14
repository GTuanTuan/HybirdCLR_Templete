using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Templete;
using System;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class UBaseController < C,P >
    where C: class,new()
    where P: UBasePanel
{
    public P ui;
    public string key;
    public void Open(Action<P> openCallBack = null)
    {
        if (ui != null)
        {
            ui.gameObject.SetActive(true);
            if (openCallBack != null) openCallBack.Invoke(ui);
        }
        else
        {
            key = $"Assets/Res/Entity/prefab/UGUI/{typeof(P).Name}.prefab";
            TestDebug.Log(key);
            AsyncOperationHandle handle = Addressables.LoadAssetAsync<GameObject>(key);
            handle.Completed += (handle1) =>
            {
                GameObject panel = GameObject.Instantiate(handle1.Result as GameObject);
                ui = panel.GetComponent<P>();
                if (openCallBack != null) openCallBack.Invoke(ui);
            };
        }
    }
    public void Close()
    {
        if (ui != null)
            ui.gameObject.SetActive(false);
    }

    protected UBaseController() { }
    ~UBaseController() { _inst = null; }
    private static C _inst;
    private static readonly object locker = new object();
    public static C Inst
    {
        get
        {
            if (_inst == null)
            {
                lock (locker)
                {
                    if (_inst == null)
                        _inst = new C();
                    Debug.Log($"Create {typeof(C)}");
                }
            }
            return _inst;
        }
    }
}
