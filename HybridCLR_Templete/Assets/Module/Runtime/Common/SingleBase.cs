using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Templete
{
    public class SingleBase<T> where T : class, new()
    {
        protected SingleBase() { }
        ~SingleBase() { singleBase = null; }
        private static T singleBase;
        private static readonly object locker = new object();
        public static T Instance()
        {
            if (singleBase == null)
            {
                lock (locker)
                {
                    if (singleBase == null)
                        singleBase = new T();
                    Debug.Log($"Create {typeof(T)}");
                }
            }
            return singleBase;
        }
    }
}

