using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class OpenDoorEvent : UnityEngine.Events.UnityEvent<bool> { }

public class LightBeamCheck : MonoBehaviour
{
    private int TriggerIdx = 0;
    public PlayableDirector playableDirector;
    public static OpenDoorEvent onOpenDoorEvent = new OpenDoorEvent();
    
    private void Update()
    {
        if (TriggerIdx >= 3)
        {
            onOpenDoorEvent.Invoke(true);
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
