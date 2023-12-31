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
    AudioSource audioSource;
    private int idx = 0;

    private void Awake()
    {
        textEffect = text.GetComponent<TextEffect>();
        audioSource = GetComponent<AudioSource>();
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
            if (isEnding && story.Count - 1 == idx)
            {
                if(!audioSource.isPlaying)
                    audioSource.Play();    
            }

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
            if (!isEnding)
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
/// 스토리 구조체
/// </summary>
[System.Serializable]
public struct StoryData
{
    //해당 스토리의 이미지
    public Sprite storySprite;

    //해당 스토리 텍스트_한글
    [TextArea(3, 5)]
    public string storyText_kor;

    //해당 스토리 텍스트_영어
    [TextArea(3, 5)]
    public string storyText_eng;
}
