using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakBlockAction : MonoBehaviour
{
    public float destroySec;
    private Animator anim;
    Rigidbody2D rigid;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartDestroyAction());    
        }
    }

    IEnumerator StartDestroyAction()
    {
        anim.SetBool("isDestroy", true);
        yield return new WaitForSeconds(destroySec);
        anim.SetBool("isDestroy", false);
        rigid.isKinematic = false;
        rigid.AddForce(Vector2.down * 5, ForceMode2D.Impulse);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
