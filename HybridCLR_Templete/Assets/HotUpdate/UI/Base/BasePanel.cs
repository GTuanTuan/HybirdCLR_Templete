using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Templete;
using FairyGUI;
using System;

public class BasePanel<T> where T:class
{
    public FGUIInstance inst;
    public GComponent root;
    public Action updateSetting;
    public Action getComs;
    public Action<T> openCallBack;
    public bool Ready;
    public FGUIInstanceSetting setting = new FGUIInstanceSetting();

    public virtual void Create()
    {
        setting.pkgName = "default";
        setting.resName = "default";
        setting.layer = "default";
        setting.add_async = true;
        setting.create_async = true;
        setting.fullScreen = false;
        setting.callback = Awake;
        if (updateSetting != null) updateSetting?.Invoke();
        new FGUIInstance(setting);
    }

    public virtual void Awake(FGUIInstance _inst)
    {
        inst = _inst;
        root = inst.root;
        if (getComs != null) getComs?.Invoke();
        Ready = true;
        if (openCallBack != null) openCallBack?.Invoke(this as T);
    }
}
