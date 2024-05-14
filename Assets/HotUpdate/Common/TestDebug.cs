using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Templete;
public class TestDebug
{
    public static bool EnableDebug = true;
    public static void Log(object msg)
    {
        if (EnableDebug)
        {
            Debug.Log(msg);
        }
    }
    public static void Log(params object[] msgList)
    {
        if (EnableDebug)
        {
            StringBuilder str = new StringBuilder("");
            foreach (object msg in msgList)
            {
                str.Append(msg + " ");
            }
            Debug.Log(str);
        }
    }
}

