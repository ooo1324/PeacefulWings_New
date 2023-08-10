using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isJohn;
    private bool isPee;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int layer = collision.gameObject.layer;
            if (layer == LayerMask.NameToLayer("Pee"))
            {
                isPee = true;
            }
            else if (layer == LayerMask.NameToLayer("John"))
            {
                isJohn = true;
            }
            else if (layer == LayerMask.NameToLayer("Pigeon"))
            {
                isJohn = true;
                isPee = true;
            }

            if (isJohn && isPee)
            {
                Debug.Log("Clear!");
                GameManager.instance.Clear();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int layer = collision.gameObject.layer;
            if (layer == LayerMask.NameToLayer("Pee"))
            {
                isPee = false;
            }
            else if (layer == LayerMask.NameToLayer("John"))
            {
                isJohn = false;
            }
            else if (layer == LayerMask.NameToLayer("Pigeon"))
            {
                isJohn = false;
                isPee = false;
            }
        }
    }
}
