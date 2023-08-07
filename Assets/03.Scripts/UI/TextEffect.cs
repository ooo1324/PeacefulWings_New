using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    public int CharPerSec;
    public GameObject EndObj;

    Text msgText;
    int idx;
    float interval;
    string targetMsg;

    [HideInInspector]
    public bool isAnimation;

    private AudioSource audioSource;

    private void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (!isAnimation)
        {
            targetMsg = msg;
            EffectStart();
        }
        else
        {
            StopAllCoroutines();
            msgText.text = targetMsg;
            EffectEnd();
        }
    }

    void EffectStart()
    {
        isAnimation = true;
        msgText.text = "";

        EndObj.SetActive(false);

        interval = 1.0f / CharPerSec;

        StartCoroutine(Effecting());
    }

    IEnumerator Effecting()
    {
        for (int i = 0; i < targetMsg.Length; i++)
        {
            msgText.text += targetMsg[i];

            if (audioSource != null)
            {
                if (targetMsg[i] != ' ' && targetMsg[i] != '.')
                    audioSource.Play();
            }

            yield return new WaitForSeconds(interval);
        }

        EffectEnd();
    }

    void EffectEnd()
    {
        isAnimation = false;
        EndObj.SetActive(true);
    }
}
