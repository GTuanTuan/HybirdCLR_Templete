using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Templete
{
    /// <summary>
    /// 布尔检查器
    /// </summary>
    public class CheckTick : MonoBehaviour
    {
        private static readonly object lockObj = new object();

        private static CheckTick __;

        private static CheckTick _ 
        {
            get
            {
                if(__ == null)
                {
                    lock (lockObj)
                    {
                        if(__ == null)
                        {
                            __ = FindObjectOfType<CheckTick>();
                            if(__ == null)
                            {
                                __ = new GameObject("CheckTick").AddComponent<CheckTick>();
                            }
                        }
                    }
                }
                return __;
            }
        }

        private void Awake()
        {
            lock (lockObj)
            {
                CheckTick[] monos = FindObjectsOfType<CheckTick>();
                if (monos.Length > 1)
                {
#if UNITY_EDITOR
                    if (Application.isPlaying)
                    {
                        Destroy(this);
                    }
                    else
                    {
                        DestroyImmediate(this);
                    }
#else
                    Destroy(this);
#endif
                }
                else
                {
                    if (Application.isPlaying)
                    {
                        DontDestroyOnLoad(gameObject);
                    }
                }
            }
        }

        private readonly LinkedList<CheckTickFunctions> functions = new LinkedList<CheckTickFunctions>();

        [SerializeField]
        private float interval = 0.033f;

        private float currInterval = 0f;

        private bool AfterInterval()
        {
            if (Time.unscaledTime - currInterval > interval)
            {
                currInterval = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新间隔
        /// </summary>
        public static float Interval
        {
            get
            {
                return _.interval;
            }
            set
            {
                if(value < 0)
                {
                    value = 0;
                }
                _.interval = value;
            }
        }

        /// <summary>
        /// 添加规则
        /// </summary>
        /// <param name="checkTickFunctions"></param>
        public static void AddRule(CheckTickFunctions.CheckTickFunc condition, CheckTickFunctions.CheckTickFunc todo)
        {
            CheckTickFunctions check = new CheckTickFunctions(condition, todo);
            if (check.Initialized)
            {
                _.functions.AddLast(check);
            }
        }

        private void Tick()
        {
            if (AfterInterval() && functions.Count > 0)
            {
                LinkedListNode<CheckTickFunctions> node = functions.First;
                while (node != null)
                {
                    CheckTickFunctions check = node.Value;
                    if (check.condition())
                    {
                        if (check.todo())
                        {
                            LinkedListNode<CheckTickFunctions> del = node;
                            node = node.Next;
                            functions.Remove(del);
                            continue;
                        }
                    }
                    node = node.Next;
                }
            }
        }

        public enum UpdateMethodEnum
        {
            Update, LateUpdate
        }

        [SerializeField]
        private UpdateMethodEnum updateMethod;

        /// <summary>
        /// 更新方法
        /// </summary>
        public static UpdateMethodEnum UpdateMethod
        {
            get
            {
                return _.updateMethod;
            }
            set
            {
                _.updateMethod = value;
            }
        }

        private void Update()
        {
            if(updateMethod == UpdateMethodEnum.Update)
            {
                Tick();
            }
        }

        private void LateUpdate()
        {
            if (updateMethod == UpdateMethodEnum.LateUpdate)
            {
                Tick();
            }
        }
    }

    /// <summary>
    /// 检查器规则函数
    /// </summary>
    public class CheckTickFunctions
    {
        public CheckTickFunctions(CheckTickFunc condition, CheckTickFunc todo)
        {
            if(condition != null && todo != null)
            {
                this.condition = condition;
                this.todo = todo;
            }
            else
            {
                Debug.LogError("CheckTickFunctions(Func<bool> condition, Func<bool> todo) 参数不能为空");
            }
        }

        /// <summary>
        /// 是否已经初始化
        /// </summary>
        public bool Initialized
        {
            get
            {
                if(condition != null && todo != null)
                {
                    return true;
                }
                return false;
            }
        }

        public delegate bool CheckTickFunc();

        /// <summary>
        /// 条件，返回true则执行todo，返回false继续下一次判断
        /// </summary>
        public CheckTickFunc condition;

        /// <summary>
        /// 执行，返回true则结束，返回false继续下一次条件判断
        /// </summary>
        public CheckTickFunc todo;
    }

}
