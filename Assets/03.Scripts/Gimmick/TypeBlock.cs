using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeBlock : MonoBehaviour
{
    public float johnDestroySec = 1f;
    public TypeBlockGen blockgen;

    float destroySec;
    private Animator anim;
    Rigidbody2D rigid;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Pee"))
            {
                destroySec = 0.1f;
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("John"))
            {
                destroySec = johnDestroySec;
            }
            StartCoroutine(StartDestroyAction());
        }
    }

    IEnumerator StartDestroyAction()
    {
        anim.SetBool("isDestroy", true);
        yield return new WaitForSeconds(destroySec);
        anim.SetBool("isDestroy", false);
        if(blockgen != null)
            blockgen.OnDestroy();
    }
}
