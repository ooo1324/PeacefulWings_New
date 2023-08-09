using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public KeyCode keyCode;
    public GameObject keyboardObj;
    public string layerType;
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
            if (AllGameData.Current_Init)
                keyboardObj.SetActive(true);

            isActive = true;
        }
        else if (layerType == "")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (AllGameData.Current_Init)
                    keyboardObj.SetActive(true);

                isActive = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(layerType))
        {
            if (AllGameData.Current_Init)
                keyboardObj.SetActive(false);

            isActive = false;
        }
        else if (layerType == "")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (AllGameData.Current_Init)
                    keyboardObj.SetActive(false);

                isActive = false;
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
