using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoLabberAction : MonoBehaviour
{
    public float waitSec = 0.5f; 
       
    public bool firstLabber = false;
    public bool secondLabber = false;
    private bool isInit = true;

    private bool timeOut = true;

    public GameObject actionObj;
    public GameObject keyObj;
    public GameObject dialogObj;

    public void CompleteAction(EBirdType type)
    {
        //if (type == EBirdType.Pee)
        //{
        //    firstAction = true;
        //}
        //else if (type == EBirdType.John)
        //{
        //    secondAction = true;
        //}



        if (isInit)
        {
            isInit = false;
            StartCoroutine(StartCount());
        }
        else
        {
            if (!timeOut)
            {
                actionObj.SetActive(true);
                keyObj.SetActive(true);
                dialogObj.SetActive(true);
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
}
