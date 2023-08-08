using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamController : MonoBehaviour
{
    private float initialAngle;
    public float maxDeltaAngle;
    public float rotationAngle;

    private void Awake()
    {
        // 현재 각도를 초기 각도로 설정합니다.
        initialAngle = transform.eulerAngles.z;
    }

    // 빛 광선을 회전시키는 메서드
    public void RotateLightBeam(int direction)
    {
        // 현재 각도를 구하고,
        float currentAngle = transform.eulerAngles.z;

        // 새로운 각도를 계산합니다.
        float newAngle = currentAngle + (rotationAngle * direction);

        // 새로운 각도가 회전 가능한 범위 내에 있는지 확인하고,
        if (Mathf.Abs(newAngle - initialAngle) <= maxDeltaAngle)
        {
            // 가능하다면 회전을 실행합니다.
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }
}
