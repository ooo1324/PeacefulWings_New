using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAction : MonoBehaviour
{
    [HideInInspector]
    public bool isPee = false;

    private Rigidbody2D rigid;

    private PlayerController playerController;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pee"))
        {
            isPee = true;
            playerController = collision.gameObject.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pee"))
        {
            isPee = false;
            Movemode(false);
            playerController.PushAnimation(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPee)
        {
            if (playerController.isPush)
            {
                playerController.PushAnimation(true);
                Movemode(true);
            }
            else
            {
                playerController.PushAnimation(false);
                Movemode(false);
            }

        }
    }

    public void Movemode(bool isMove)
    {
        if (isMove)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }

}
