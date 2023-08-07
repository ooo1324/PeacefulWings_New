using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class ButtonAction : MonoBehaviour
{
    public GameObject actionObj;

    public Animator anim;

    public PlayableDirector playableDirector;

    private bool isInit = false;

    IEnumerator BtAction()
    {
        isInit = true;
        anim.SetTrigger("doDown");
        yield return new WaitForSeconds(0.5f);
        actionObj.SetActive(true);
        if (playableDirector != null)
        {
            playableDirector.Play();
        }
  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!isInit)
                StartCoroutine(BtAction());
        }
    }
}
