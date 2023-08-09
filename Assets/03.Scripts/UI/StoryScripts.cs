using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryScripts : MonoBehaviour
{
    public List<StoryData> story;
    public Text text;
    public Image storyImg;
    public bool isEnding;

    TextEffect textEffect;
    private int idx = 0;

    private void Awake()
    {
        textEffect = text.GetComponent<TextEffect>();
    }

    private void Start()
    {
        StoryStart(idx);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            if (!textEffect.isAnimation)
            {
                idx++;
            }
            StoryStart(idx); 
        }
    } 

    /// <summary>
    /// ���丮 ��� �Լ�
    /// </summary>
    /// <param name="idx">��� ���丮 index</param>
    public void StoryStart(int idx)
    {
        if (story.Count > idx)
        {
            if (story[idx].storySprite == null)
                storyImg.color = Color.black;
            else
                storyImg.color = Color.white;

            storyImg.sprite = story[idx].storySprite;
            if (AllGameData.isEng)
            {
                textEffect.SetMsg(story[idx].storyText_eng);
            }
            else
            {
                textEffect.SetMsg(story[idx].storyText_kor);
            }
         
        }
        else
        {
            if (isEnding)
            {

            }
            else
            {

                AllGameData.Current_Level += 1;
                //Next Scene
                SceneManager.LoadScene(AllGameData.Current_Level);
            }

        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

/// <summary>
/// ���丮 ����ü
/// </summary>
[System.Serializable]
public struct StoryData
{
    //�ش� ���丮�� �̹���
    public Sprite storySprite;

    //�ش� ���丮 �ؽ�Ʈ_�ѱ�
    [TextArea(3, 5)]
    public string storyText_kor;

    //�ش� ���丮 �ؽ�Ʈ_����
    [TextArea(3, 5)]
    public string storyText_eng;
}
