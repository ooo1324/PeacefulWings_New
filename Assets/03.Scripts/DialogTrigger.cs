using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogSystem dialogSystem;
    public EDialogType dialogType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(AllGameData.Current_Init)
                dialogSystem.TalkStart(dialogType);

            gameObject.SetActive(false);
        }
    }
}
