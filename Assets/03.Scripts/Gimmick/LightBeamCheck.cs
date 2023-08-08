using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LightBeamCheck : MonoBehaviour
{
    private int TriggerIdx = 0;
    public PlayableDirector playableDirector;

    private void Update()
    {
        if (TriggerIdx >= 2)
        {
            playableDirector.gameObject.SetActive(true);
            playableDirector.Play();
            TriggerIdx = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LightBeam"))
        {
            TriggerIdx++;
        }  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LightBeam"))
        {
            TriggerIdx--;
        }
    }
}
