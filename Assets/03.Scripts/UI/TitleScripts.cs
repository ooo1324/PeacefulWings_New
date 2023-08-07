using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScripts : MonoBehaviour
{
    public void StoryScene()
    {
        AllGameData.Current_Level += 1;
        SceneManager.LoadScene(AllGameData.Current_Level);
    }
}
