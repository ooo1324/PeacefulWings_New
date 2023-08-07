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
    /// 스토리 재생 함수
    /// </summary>
    /// <param name="idx">재생 스토리 index</param>
    public void StoryStart(int idx)
    {
        if (story.Count > idx)
        {
            if (story[idx].storySprite == null)
                storyImg.color = Color.black;
            else
                storyImg.color = Color.white;

            storyImg.sprite = story[idx].storySprite;
            textEffect.SetMsg(story[idx].storyText);
        }
        else
        {
            AllGameData.Current_Level += 1;
            //Next Scene
            SceneManager.LoadScene(AllGameData.Current_Level);
            // SceneManager.LoadScene("TestScene");
           
        }
    }
}

/// <summary>
/// 스토리 구조체
/// </summary>
[System.Serializable]
public struct StoryData
{
    //해당 스토리의 이미지
    public Sprite storySprite;

    //해당 스토리 텍스트
    [TextArea(3, 5)]
    public string storyText;
}
