using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{

    public float arrowSpeed;
    public Transform currentLocation;
    public Transform target;
    public GameObject circleSprite;
    public GameObject arrowSprite;

    private Vector3 targetPosition;
    // Update is called once per frame
    void Update()
    {
        ArrowHint();
    }

    private void ArrowHint()
    {

        Vector3 pos = Camera.main.WorldToViewportPoint(target.position);

        if ((pos.x < 1.0f && pos.x > 0.0f) && (pos.y < 1.0f && pos.y > 0.0f))
        {
            transform.position = Camera.main.ViewportToWorldPoint(pos);
            if (circleSprite.gameObject.activeSelf)
            {
                circleSprite.SetActive(false);
                arrowSprite.SetActive(false);
            }
            return;
        }

        if (!circleSprite.gameObject.activeSelf)
        {
            circleSprite.SetActive(true);
            arrowSprite.SetActive(true);
        }
          

        pos *= 2.0f;
        pos = new Vector3(pos.x - 1, pos.y - 1, pos.z - 1);

        if (Mathf.Abs(pos.x) > Mathf.Abs(pos.y))
        {
            pos.y = pos.y / Mathf.Abs(pos.x);
            if (pos.x > 1)
                pos.x = 1;
            else if (pos.x < -1)
                pos.x = -1;
        }
        else
        {
            pos.x = pos.x / Mathf.Abs(pos.y);
            if (pos.y > 1)
                pos.y = 1;
            else if (pos.y < -1)
                pos.y = -1;
        }
        pos = new Vector3(pos.x + 1, pos.y + 1, pos.z + 1);
        pos /= 2.0f;
        transform.position = Vector3.Lerp(transform.position, Camera.main.ViewportToWorldPoint(pos), Time.deltaTime * arrowSpeed);

        transform.transform.LookAt(target);
        //arrowSprite.transform.LookAt(target);
        //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}