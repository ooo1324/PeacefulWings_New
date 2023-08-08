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
        // ���� ������ �ʱ� ������ �����մϴ�.
        initialAngle = transform.eulerAngles.z;
    }

    // �� ������ ȸ����Ű�� �޼���
    public void RotateLightBeam(int direction)
    {
        // ���� ������ ���ϰ�,
        float currentAngle = transform.eulerAngles.z;

        // ���ο� ������ ����մϴ�.
        float newAngle = currentAngle + (rotationAngle * direction);

        // ���ο� ������ ȸ�� ������ ���� ���� �ִ��� Ȯ���ϰ�,
        if (Mathf.Abs(newAngle - initialAngle) <= maxDeltaAngle)
        {
            // �����ϴٸ� ȸ���� �����մϴ�.
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }
}
