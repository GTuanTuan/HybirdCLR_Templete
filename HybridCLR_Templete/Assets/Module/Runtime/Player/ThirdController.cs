using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Templete
{
    public class ThirdController : MoveController
    {
        float angle ;
        float idle_x;
        float[] radius = new float[3] { 3,5,2};
        public GameObject idle_Cam;
        private void OnEnable()
        {
            SetRenderer(true);
            if (forward_obj)
            {
                Quaternion quaternion = controller.transform.localRotation;
                idle_Cam.GetComponent<Cinemachine.CinemachineFreeLook>().m_XAxis.Value = controller.transform.localEulerAngles.y;
                controller.transform.localRotation = Quaternion.AngleAxis(0, Vector3.up);
                forward_obj.localRotation = quaternion;
            }
        }
        private void Awake()
        {
            cam = idle_Cam.transform;
            InitAnimData();
            AnimController.Instance().AddAnimationEvent(animator, "Aris_Original_Normal_Attack_Ing", "Attack", 1.02f);
        }
        private void Update()
        {
            UpdateAxis();
            SetCamRadius();
            GetTarget();
            SetcanMove();
            SetForward();
            AddGravity();
            SetAnimData();
            ApplyAnimData();
            Move();
        }
        private void LateUpdate()
        {
            Rotate();
        }
        void Rotate()
        {
            idle_x = idle_Cam.GetComponent<Cinemachine.CinemachineFreeLook>().m_XAxis.Value;
            forward_obj.localRotation = Quaternion.AngleAxis(idle_x, Vector3.up);
        }
        void SetForward()
        {
            if (GetVerticalVelocity() != 0)
                angle = GetVerticalVelocity() > 0 ? 0+ idle_x : 180+ idle_x;
            if (GetHorizontalVelocity() != 0)
                angle = GetHorizontalVelocity() > 0 ? 90 + idle_x : 270 + idle_x;
            animator.gameObject.transform.DOLocalRotateQuaternion(Quaternion.AngleAxis(angle, Vector3.up), 0.5f);
        }
        void SetAnimData()
        {
            animData.bool_map[AnimController.Instance().MoveID] = TargetNotZero()||onNav;
            animData.bool_map[AnimController.Instance().AttackID] = Input.GetKey(KeyCode.Mouse0);
        }
        void SetcanMove()
        {
            bool isMovingEnd = animator.GetCurrentAnimatorStateInfo(0).IsName("Aris_Original_Move_End_Normal") || animator.GetNextAnimatorStateInfo(0).IsName("Aris_Original_Move_End_Normal");
            bool isAttack = animator.GetCurrentAnimatorStateInfo(0).IsTag("OnAttack");
            onNav = onNav && !isMovingEnd && !isAttack;
            canMoveByKey = TargetNotZero()&&!isMovingEnd&&!isAttack;
        }
        void SetCamRadius()
        {
            for (int i = 0; i < radius.Length; i++)
            {
                radius[i] -= Input.GetAxis("Mouse ScrollWheel") * 2;
                if (radius[i] < 1) radius[i] = 1; else if (radius[i] > 10) radius[i] = 10;
                idle_Cam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[i].m_Radius = Mathf.Lerp(
                    idle_Cam.GetComponent<Cinemachine.CinemachineFreeLook>().m_Orbits[i].m_Radius, radius[i], Time.deltaTime);
            }
        }
    }
}

