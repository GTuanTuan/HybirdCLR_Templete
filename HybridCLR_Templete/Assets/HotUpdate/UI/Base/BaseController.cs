using System;
using System.Collections;
using System.Collections.Generic;
using Templete;
using UnityEngine;

public class BaseController<C,P> 
    where C: class,new()
    where P:BasePanel<P>,new()
    
{
    public P ui;
    public void Open(Action<P> openCallBack = null)
    {
        if (ui != null && ui.root != null)
        {
            ui.inst.SetActive(true);
        }
        else
        {
            ui = new P();
            if (openCallBack != null)
                ui.openCallBack = openCallBack;
            ui.Create();
        }
    }
    public void Close()
    {
        if (ui != null && ui.root != null)
            ui.inst.SetActive(false);
    }

    protected BaseController() { }
    ~BaseController() { _inst = null; }
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
