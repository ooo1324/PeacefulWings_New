using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeBlockGen : MonoBehaviour
{
    public GameObject typeBlockObj;
    public float delaySec;
    private bool isActive;

    private void Start()
    {
        isActive = true;
    }

    public void OnDestroy()
    {
        if(isActive)
            StartCoroutine(delayCreate());
    }

    IEnumerator delayCreate()
    {
        isActive = false;
        typeBlockObj.SetActive(false);
        yield return new WaitForSeconds(delaySec);
        typeBlockObj.SetActive(true);
        isActive = true;
    }
}
