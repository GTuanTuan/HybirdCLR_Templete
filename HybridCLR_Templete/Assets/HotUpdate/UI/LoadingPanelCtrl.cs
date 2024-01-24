using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Templete;
using System;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Networking;

public class LoadingPanelCtrl : BaseController<LoadingPanelCtrl, LoadingPanel>
{
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
