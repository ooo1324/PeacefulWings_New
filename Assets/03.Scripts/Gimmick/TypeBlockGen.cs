using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeBlockGen : MonoBehaviour
{
    public GameObject typeBlockObj;
    public float delaySec;
    private bool isActive;
    private GameObject obj;

    private void Start()
    {   
        obj = Instantiate(typeBlockObj, gameObject.transform);
        obj.GetComponent<TypeBlock>().blockgen = this;
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
        Destroy(obj);
        yield return new WaitForSeconds(delaySec);
        obj = Instantiate(typeBlockObj, gameObject.transform);
        if(obj !=null)
            obj.GetComponent<TypeBlock>().blockgen = this;
        isActive = true;
    }
}
