using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosManager : MonoBehaviour
{
    public static PosManager instance;

    public CameraControl cameraControl;

    public float minDist;
    public float divideDist = 0.7f;

    [HideInInspector]
    public float dist;

    [HideInInspector]
    bool isActivePigeon;

    public bool isPigeonActive = false;


    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();

        if (isPigeonActive)
        {
            // isGrounded 확인해서 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GameManager.instance.pigeon.gameObject.activeSelf)
                {
                    Vector2 pigeonVec = GameManager.instance.pigeon.transform.position;
                    GameManager.instance.pigeon.SetActive(false);
                    GameManager.instance.leftBird.transform.position = new Vector3(pigeonVec.x + divideDist, pigeonVec.y);
                    GameManager.instance.rightBird.transform.position = new Vector3(pigeonVec.x - divideDist, pigeonVec.y);
                    GameManager.instance.leftBird.SetActive(true);
                    GameManager.instance.rightBird.SetActive(true);

                    cameraControl.SwichTarget();
                }
                else
                {
                    if (isActivePigeon)
                    {
                        GameManager.instance.pigeon.gameObject.transform.position = GameManager.instance.leftBird.transform.position;
                        GameManager.instance.pigeon.SetActive(true);
                        GameManager.instance.leftBird.SetActive(false);
                        GameManager.instance.rightBird.SetActive(false);

                        cameraControl.SwichTarget();
                    }
                }

            }
        }
     
    }

    void CheckDistance()
    {
        dist = Vector2.Distance(GameManager.instance.leftBird.transform.position, GameManager.instance.rightBird.transform.position);

        isActivePigeon = dist <= minDist;
       
        //if (isActivePigeon)
        //{
              //둘이 붙을 수 있는 상태라는 것을 직관적으로 보이게 하는 것이 필요함
        //    Debug.Log("Active 가능");
        //}
    }

    
}
