using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
namespace Templete
{
    public class FGUIInstance
    {
        public FGUIInstanceSetting _setting;
        public GComponent root;
        public FGUIInstance(FGUIInstanceSetting setting)
        {
            _setting = setting;
            CreateInstance();
        }
        public void SetActive(bool active)
        {
            if (root != null) root.visible = active;
        }
        void CreateInstance()
        {
            void _create()
            {
                if (_setting.create_async)
                {
                    DoCreateAsync();
                }
                else
                {
                    DoCreate();
                }
            }
            if (_setting.add_async)
            {
                FGUIManager.Instance.AddPackage(_setting.pkgName, true);
                CheckTick.AddRule(
                    () =>{return FGUIManager.Instance.CheckAdd(_setting.pkgName) == 1;},
                    () =>{ _create();return true;});
            }
            else
            {
                FGUIManager.Instance.AddPackage(_setting.pkgName);
                _create();
            }
        }
        void DoCreate()
        {
            root = UIPackage.CreateObject(_setting.pkgName, _setting.resName).asCom;
            CreateComplete();
        }
        void DoCreateAsync()
        {
            UIPackage.CreateObjectAsync(_setting.pkgName, _setting.resName,(inst)=> {
                root = inst.asCom;
                CreateComplete();
            });
        }
        void CreateComplete()
        {
            if (root!=null)
            {
                GComponent layer = GRoot.inst.GetChild(_setting.layer).asCom;
                layer.AddChild(root);
                if(_setting.fullScreen) root.MakeFullScreen();
                if (_setting.callback != null) _setting.callback?.Invoke(this);
            }
        }

    }
    public class FGUIInstanceSetting
    {
        public string pkgName;
        public string resName;
        public string layer;
        public bool add_async;
        public bool create_async;
        public Action<FGUIInstance> callback;
        public bool fullScreen;
    }
}

