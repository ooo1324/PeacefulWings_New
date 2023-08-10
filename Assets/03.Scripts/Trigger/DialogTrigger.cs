using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogSystem dialogSystem;
    public EDialogType dialogType;

    public int dialogIdx = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!AllGameData.dialogFlagList[dialogType])
            {
                AllGameData.dialogFlagList[dialogType] = true;
                dialogSystem.TalkStart(dialogType);
            }        

            gameObject.SetActive(false);
        }
    }
}
