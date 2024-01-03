using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Templete
{
    public class FirstController : MoveController
    {
        float cur_horizAxis = 0f;
        public GameObject first_cam;
        private void OnEnable()
        {
            SetRenderer(false);
            if (forward_obj)
            {
                Quaternion quaternion = forward_obj.localRotation;
                cur_horizAxis = forward_obj.localEulerAngles.y;
                forward_obj.localRotation = Quaternion.AngleAxis(0, Vector3.up);
                controller.transform.localRotation = quaternion;
            }
        }
        private void Awake()
        {
            cam = first_cam.transform;
            canMoveByKey = true;
        }
        private void Update()
        {
            UpdateAxis();
            GetTarget();
            AddGravity();
            Move();
        }
        private void LateUpdate()
        {
            Rotate();
        }

        void Rotate()
        {
            cur_horizAxis += Input.GetAxis("Mouse X");
            controller.transform.localRotation = Quaternion.AngleAxis(cur_horizAxis, Vector3.up);
        }
    }
}

