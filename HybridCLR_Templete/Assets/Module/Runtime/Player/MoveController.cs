using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Templete
{
    public class MoveController : MonoBehaviour
    {
        public Transform cam;
        public Transform forward_obj;
        public UnityEngine.AI.NavMeshAgent nav;
        public List<SkinnedMeshRenderer> renderers = new List<SkinnedMeshRenderer>();
        public CharacterController controller;
        public Animator animator;
        public AnimData animData = new AnimData();
        //前后
        public readonly MyInputAxis verticalAxis = new MyInputAxis();
        //左右
        public readonly MyInputAxis horizontalAxis = new MyInputAxis();
        //上下
        public readonly MyInputAxis upAndDownAxis = new MyInputAxis();
        //加速
        public readonly MyInputAxis speedUpAxis = new MyInputAxis();
        [Header("前后")]
        public float moveSpeed = 10f;
        public KeyCode forwardKey = KeyCode.W;
        public KeyCode backKey = KeyCode.S;
        [Header("左右")]
        public float turnSpeed = 8f;
        public KeyCode leftKey = KeyCode.A;
        public KeyCode rightKey = KeyCode.D;
        [Header("跳跃")]
        public float jumpSpeed = 12f;
        public KeyCode jumpKey = KeyCode.Space;
        [Header("加速")]
        public float multiple = 2f;
        public KeyCode multipleKey = KeyCode.LeftShift;
        [Header("重力大小"), SerializeField]
        public float gravityValue = 0.98f;
        public bool canMoveByKey;
        public bool canRotate;
        public bool onNav;

        public Vector3 target = Vector3.zero;
        public Vector3 gravityVelocity = Vector3.zero;

        public void CheckMouseNav()
        {
            if (Cursor.lockState!= CursorLockMode.Locked&& Cursor.visible&& Input.GetKeyDown(KeyCode.Mouse1))
            {
                RaycastHit raycastHit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out raycastHit))
                {
                    MoveByNav(raycastHit.point);
                }                 
            }
            CheckNavDest();
        }
        public void CheckNavDest()
        {
            if( !nav.isStopped &&nav.speed> 0)
            {
                if (!nav.pathPending && nav.remainingDistance < 0.5f) ResetNav();
            }
        }
        public void MoveByNav(Vector3 target)
        {
            nav.destination = target;
            nav.isStopped = false;
            nav.speed = 5;
            onNav = true;
        }
        public void ResetNav()
        {
            nav.isStopped = true;
            nav.speed = 0;
            onNav = false;
        }
        public void SetRenderer(bool value)
        {
            foreach (var renderer in renderers)
            {
                renderer.enabled = value;
            }
        }
        public void GetTarget()
        {
            if (controller.isGrounded )
            {
                if (canMoveByKey)
                {
                    ResetNav();
                    target = new Vector3(GetHorizontalVelocity(), 0, GetVerticalVelocity());
                    target *= GetSpeedUpMultiple();
                    target = forward_obj.transform.TransformDirection(target);
                }
                else
                {
                    target = new Vector3(0, target.y, 0);
                }

                target += Vector3.up * GetUpAndDownVelocity();
            }
        }
        public void AddGravity()
        {
            if (controller.isGrounded)
            {
                gravityVelocity = Vector3.zero;
            }
            else
            {
                Vector3 gravity = Vector3.down * gravityValue;
                gravityVelocity += gravity * Time.deltaTime;
                target += gravityVelocity;
            }
        }
        public void Move()
        {
            CheckMouseNav();
            if (!onNav)
                controller.Move(target * Time.deltaTime);
        }
        public void InitAnimData()
        {
            animData.animator = animator;
            animData.bool_map.Add(AnimController.Instance().MoveID, false);
            animData.bool_map.Add(AnimController.Instance().AttackID, false);
        }
        public void ApplyAnimData()
        {
            AnimController.Instance().SetAnim(animData);
        }
        public void UpdateAxis()
        {
            verticalAxis.positiveKey = forwardKey;
            verticalAxis.negativeKey = backKey;
            verticalAxis.Update();
            horizontalAxis.positiveKey = rightKey;
            horizontalAxis.negativeKey = leftKey;
            horizontalAxis.Update();
            speedUpAxis.positiveKey = multipleKey;
            speedUpAxis.Update();
            upAndDownAxis.positiveKey = jumpKey;
            upAndDownAxis.Update();
        }
        public float GetHorizontalVelocity()
        {
            return  horizontalAxis.value * turnSpeed;
        }

        public float GetVerticalVelocity()
        {
            return  verticalAxis.value * moveSpeed;
        }

        public float GetSpeedUpMultiple()
        {
            return speedUpAxis.value > 0 ? 1 + speedUpAxis.value * multiple : 1;
        }

        public float GetUpAndDownVelocity()
        {
            return upAndDownAxis.value > 0 ? jumpSpeed : 0;
        }
        public bool TargetNotZero()
        {
            return GetHorizontalVelocity() != 0 || GetVerticalVelocity() != 0;
        }
        public bool Moving()
        {
            return (TargetNotZero()&& canMoveByKey)|| onNav;
        }
    }
}

