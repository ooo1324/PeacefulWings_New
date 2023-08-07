using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonItem : MonoBehaviour
{
    BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PosManager.instance.isPigeonActive = true;

            boxCollider.enabled = false;
        }
    }
}
