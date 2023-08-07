using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonItem : MonoBehaviour
{
    BoxCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PosManager.instance.isPigeonActive = true;

            collider.enabled = false;
        }
    }
}
