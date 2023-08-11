using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TwoLabberAction_puzzle : MonoBehaviour
{
    public float waitSec = 0.5f;
    
    public bool firstLabber = false;
    public bool secondLabber = false;
    private bool isInit = true;
    private bool timeOut = true;

    public LabberAction_puzzle firstLever;
    public LabberAction_puzzle secondLever;

    public void CompleteAction(EBirdType type)
    {
        if (isInit)
        {
            isInit = false;
            StartCoroutine(StartCount());
        }
        else
        {
            if (!timeOut)
            {
                StartCoroutine(ActiveAction());
            }
        }

    }

    IEnumerator StartCount()
    {
        timeOut = false;
        yield return new WaitForSeconds(waitSec);
        timeOut = true;
        isInit = true;
    }

    IEnumerator ActiveAction()
    {
        yield return new WaitForSeconds(0.2f);
        foreach (LightBeamController beam in firstLever.beams)
        {
            beam.RotateLightBeam(firstLever.direction);
        }
        foreach (LightBeamController beam in secondLever.beams)
        {
            beam.RotateLightBeam(secondLever.direction);
        }
    }
}
