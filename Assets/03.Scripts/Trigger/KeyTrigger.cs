using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public KeyCode keyCode;
    public GameObject keyboardObj;
    public string layerType;
    public EDialogType dialogType;
    private bool isActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (isActive)
            {
                StartCoroutine(Action());
            }
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(layerType))
        {
            Active();
        }
        else if (layerType == "")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Active();
            }
        }
    }

    private void Active()
    {
        keyboardObj.SetActive(true);

        isActive = true;
    }

    private void NonActive()
    {
        keyboardObj.SetActive(false);

        isActive = false;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(layerType))
        {
            NonActive();
        }
        else if (layerType == "")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                NonActive();
            }
        }
    }

    IEnumerator Action()
    {
        yield return new WaitForSeconds(1);
        keyboardObj.SetActive(false);
        gameObject.SetActive(false);
    }
}
