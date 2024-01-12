using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Templete
{
    public class PreloadPanel : MonoBehaviour
    {
        //// Start is called before the first frame update
        GComponent root;
        GLoader bg;
        GProgressBar bar;
        GTextField title;
        void Start()
        {
            UIPanel panel = gameObject.GetComponent<UIPanel>();
            root = panel.ui;
            bg = root.GetChild("bg").asLoader;
            bar = root.GetChild("bar").asProgress;
            title = root.GetChild("title").asTextField;
        }

        public void SetBar(float value)
        {
            if (bar != null)
                bar.value = value;
        }
        public void SetTitle(string name)
        {
            if (title != null)
                title.text = name;
        }
        public void SetVisible(bool value)
        {
            if (root != null)
                root.visible = value;
        }
    }
}

