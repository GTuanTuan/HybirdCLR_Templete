using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Templete
{
    public class AnimController : SingleBase<AnimController>
    {
        public int MoveID = Animator.StringToHash("Move");
        public int AttackID = Animator.StringToHash("Attack");
        public void SetAnim(AnimData data)
        {
            if (data.animator)
            {
                foreach (var kv in data.bool_map)
                {
                    data.animator.SetBool(kv.Key, kv.Value);
                }
                foreach (var kv in data.float_map)
                {
                    data.animator.SetFloat(kv.Key, kv.Value);
                }
                foreach (var kv in data.int_map)
                {
                    data.animator.SetInteger(kv.Key, kv.Value);
                }
            }
        }
        public void AddAnimationEvent(Animator animator, string aniName, string functionName,float time)
        {
            AnimationEvent evt = new AnimationEvent();
            evt.functionName = functionName;
            evt.time = time;
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < clips.Length; i++)
            {
                if (clips[i].name.Equals(aniName))
                {
                    clips[i].AddEvent(evt);
                }
            }
        }
    }

    public class AnimData
    {
        public Animator animator;
        public Dictionary<int, bool> bool_map = new Dictionary<int, bool>();
        public Dictionary<int, float> float_map = new Dictionary<int, float>();
        public Dictionary<int, int> int_map = new Dictionary<int, int>();
    }
}

