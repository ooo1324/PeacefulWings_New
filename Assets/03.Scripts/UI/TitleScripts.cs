using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScripts : MonoBehaviour
{
    public void StoryScene()
    {
        AllGameData.Current_Level += 1;
        SceneManager.LoadScene(AllGameData.Current_Level);
    }
    public void CreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OnToggleValueChanged(bool isChange)
    {
        AllGameData.isEng = isChange;
    }
}
