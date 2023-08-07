using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float DestroySec;

    Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Startbullet());
    }

    IEnumerator Startbullet()
    {
        rigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(DestroySec);

        Destroy(gameObject);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Destroy(gameObject);
        }

    }
}
