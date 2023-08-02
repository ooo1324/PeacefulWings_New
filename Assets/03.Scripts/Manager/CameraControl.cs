using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    EBirdType currFollowType;

    private CinemachineVirtualCamera vcam;

    EBirdType preFollowType;

    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        currFollowType = EBirdType.Pee;
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TargetChange(EBirdType.Pee);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TargetChange(EBirdType.John);
        }
    }

    public void SwichTarget()
    {
        if (currFollowType != EBirdType.Pigeon)
        {
            preFollowType = currFollowType;
            //������ ���°� �ƴҶ� -> ��ģ ���·� ����
            TargetChange(EBirdType.Pigeon);
        }
        else
        {
            //������ �����϶� -> �и����·� ����
            TargetChange(preFollowType);
        }

    }

    public void TargetChange(EBirdType targetType)
    {
        currFollowType = targetType;
        switch (targetType)
        {
            case EBirdType.Pee:
                vcam.Follow = GameManager.instance.leftBird.transform;
                break;
            case EBirdType.John:
                vcam.Follow = GameManager.instance.rightBird.transform;
                break;
            case EBirdType.Pigeon:
                vcam.Follow = GameManager.instance.pigeon.transform;
                break;
        }

    }

}