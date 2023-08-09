using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScripts : MonoBehaviour
{
    public void TitleScene()
    {
        AllGameData.Current_Level = 0;
        SceneManager.LoadScene(AllGameData.Current_Level);
    }
}
