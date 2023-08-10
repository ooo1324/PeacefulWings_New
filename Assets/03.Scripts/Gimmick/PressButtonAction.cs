using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PressButtonAction : MonoBehaviour
{
    public GameObject abledObj;
    public GameObject disabledObj;

    public Animator anim;

    public PlayableDirector playableDirector;

    private bool isInit = false;
    private int tiggerIdx = 0;

    IEnumerator BtAction()
    {
        anim.SetBool("isPress", true);
        yield return new WaitForSeconds(0.5f);
        if (!isInit)
        {
            isInit = true;
            if (playableDirector != null)
            {
                playableDirector.Play();
            }
        }
        else
        {
            abledObj.SetActive(true);
            disabledObj.SetActive(false);
        }
    }

    IEnumerator BtAction_Disalbe()
    {
        tiggerIdx = 0;
        anim.SetBool("isPress", false);
        yield return new WaitForSeconds(0.3f);

        abledObj.SetActive(false);
        disabledObj.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            tiggerIdx++;
            if (!anim.GetBool("isPress"))
            {
                StartCoroutine(BtAction());
            }
      
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            tiggerIdx--;
            if (tiggerIdx <= 0)
            {
                if (anim.GetBool("isPress"))
                {
                    StartCoroutine(BtAction_Disalbe());
                }
            }     
        }
    }
}
