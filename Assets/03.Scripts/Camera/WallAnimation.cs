using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimation : MonoBehaviour
{
    public Animator wall_anim;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        wall_anim.SetTrigger("doBroke");
        StartCoroutine(BrokenSound());

    }

    IEnumerator BrokenSound()
    {
        yield return new WaitForSeconds(0.2f);

        audioSource.Play();
    }
}
