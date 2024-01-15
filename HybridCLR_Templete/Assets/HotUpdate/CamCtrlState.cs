using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Templete;
using Cinemachine;

public class CamCtrlState : MonoBehaviour
{
    public GameObject third;
    public GameObject player;
    public GameObject first;
    bool state = true;
    bool mlock = true;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        bool SetCamState()
        {
            if(third && player && first)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    state = !state;
                    third.SetActive(state);
                    first.SetActive(!state);
                    CinemachineBrain.SoloCamera = state ? third.GetComponentInChildren<CinemachineFreeLook>() : first.GetComponent<CinemachineVirtualCamera>();
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                mlock = !mlock;
                Cursor.visible = !mlock;
                Cursor.lockState = mlock ? CursorLockMode.Locked : CursorLockMode.None;
            }
            return false;
        }
        CheckTick.AddRule(SetCamState,()=> { return false; });
    }
    void Init()
    {
        third.SetActive(state);
        first.SetActive(!state);
        CinemachineBrain.SoloCamera = state ? third.GetComponentInChildren<CinemachineFreeLook>() : first.GetComponent<CinemachineVirtualCamera>();
        Cursor.visible = !mlock;
        Cursor.lockState = mlock ? CursorLockMode.Locked : CursorLockMode.None;
        Debug.Log("third:"+state + ",lock:" + mlock);
    }
}
