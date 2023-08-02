using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScripts : MonoBehaviour
{
    public void StoryScene()
    {
        SceneManager.LoadScene("StoryScene");
    }
}
