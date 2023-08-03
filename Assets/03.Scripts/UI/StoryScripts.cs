using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryScripts : MonoBehaviour
{
    public List<string> talkData;
    public List<Sprite> spriteList;
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

    public void StoryStart(int idx)
    {
        if (talkData.Count > idx)
        {
            if (spriteList[idx] == null)
                storyImg.color = Color.black;
            else
                storyImg.color = Color.white;

            storyImg.sprite = spriteList[idx];
            textEffect.SetMsg(talkData[idx]);
        }
        else
        {
            //Next Scene
            SceneManager.LoadScene("Stage1Scene");
            AllGameData.Current_Level = 1;
        }
    }
}
 