using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Templete;
using System;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Networking;

public class LoadingPanelCtrl : BaseController<LoadingPanelCtrl, LoadingPanel>
{
    public void Open(List<AsyncOperationHandle> handles, string msg = "", bool close = true)
    {
        Open((_ui) => {
            Init(msg);
            LoadingWithAddressable(handles, close);
        });
    }
    public void Open(AsyncOperationHandle handle, string msg = "", bool close = true)
    {
        Open((_ui) => {
            Init(msg);
            LoadingWithAddressable(handle, close);
        });
    }
    public void Open(UnityWebRequest req, string msg = "", bool close = true)
    {
        Open((_ui) => {
            Init(msg);
            LoadingWithWebRequest(req, close);
        });
    }
    public void Open(string msg = "")
    {
        Open((_ui) => { Init(msg); });
    }
    void LoadingWithAddressable(AsyncOperationHandle handle, bool close)
    {

        CheckTick.AddRule(() =>
        {
            ui.SetValue(Mathf.Lerp(ui.curValue, handle.PercentComplete, Time.deltaTime));
            return handle.IsDone;
        },
        () =>
        {
            if (close) Close();
            return true;
        });
    }
    void LoadingWithAddressable(List<AsyncOperationHandle> handles, bool close)
    {
        float progress = 0;
        bool allComplete;
        CheckTick.AddRule(() =>
        {
            progress = 0;
            allComplete = true;
            foreach (AsyncOperationHandle handle in handles)
            {
                progress += handle.PercentComplete;
                if (!handle.IsDone) allComplete = false;
            }
            progress = progress / handles.Count;
            ui.SetValue(Mathf.Lerp(ui.curValue, progress, Time.deltaTime));
            return allComplete;
        },
        () =>
        {
            if (close) Close();
            return true;
        });
    }

    void LoadingWithWebRequest(UnityWebRequest req, bool close)
    {
        CheckTick.AddRule(() =>
        {
            ui.SetValue(Mathf.Lerp(ui.curValue, req.downloadProgress, Time.deltaTime));
            return req.isDone;
        },
        () =>
        {
            if (close) Close();
            return true;
        });
    }
    void Init(string msg = "")
    {
        ui.title.text = msg;
        ui.SetValue(0);
    }
}
