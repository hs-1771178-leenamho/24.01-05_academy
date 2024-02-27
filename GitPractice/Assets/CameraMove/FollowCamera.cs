using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowCamera : MonoBehaviour
{
    enum DIRECTION
    {
        FOWARD,
        BACK,
        UP,
        DOWN
    }
    [SerializeField] List<Transform> cameraLookPos;
    [SerializeField] Transform playerTransform;
    CinemachineVirtualCamera cine;
    // Start is called before the first frame update
    void Start()
    {
        cine = GetComponent<CinemachineVirtualCamera>();
        cine.Follow = playerTransform;
    }

    // Update is called once per frame
    void Update()
    {
        CameraSwitch();
    }

    void CameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            cine.Follow = cameraLookPos[(int)DIRECTION.FOWARD];
        }
        if (Input.GetKeyUp(KeyCode.Keypad6))
        {
            cine.Follow = playerTransform;
        }
        
        if (Input.GetKey(KeyCode.Keypad4))
        {
            cine.Follow = cameraLookPos[(int)DIRECTION.BACK];
        }
        if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            cine.Follow = playerTransform;
        }

        if (Input.GetKey(KeyCode.Keypad8))
        {
            cine.Follow = cameraLookPos[(int)DIRECTION.UP];
        }
        if (Input.GetKeyUp(KeyCode.Keypad8))
        {
            cine.Follow = playerTransform;
        }

        if (Input.GetKey(KeyCode.Keypad2))
        {
            cine.Follow = cameraLookPos[(int)DIRECTION.DOWN];
        }
        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            cine.Follow = playerTransform;
        }
    }
}
