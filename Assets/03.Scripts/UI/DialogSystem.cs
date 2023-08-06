using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    //public Dictionary<string, List<DialogData>> talkDic;

    public List<DialogData> talkDic;
    public List<Sprite> peeSpriteList;
    public List<Sprite> johnSpriteList;
    public TextEffect peeText;
    public TextEffect johnText;
    public Image peeImg;
    public Image johnImg;
    public AudioClip peeAudioClip;
    public AudioClip johnAudioClip;

    //Test
    public GameObject Pee;
    public GameObject John;

    private int idx;

    private List<DialogData> currTalkList;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        idx = 0;
        TalkStart("");
    }

    public void TalkStart(string key)
    {
        //currTalkList = talkDic[key];
        currTalkList = talkDic;
        NextTalk(idx, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {     
            if (currTalkList.Count > idx)
            {
                bool isSound = false;
                if (currTalkList[idx].birdType == EBirdType.Pee)
                {
                    if (!peeText.isAnimation)
                    {
                        idx++;
                        isSound = true;
                    }
                }
                else if (currTalkList[idx].birdType == EBirdType.John)
                {
                    if (!johnText.isAnimation)
                    {
                        idx++;
                        isSound = true;
                    }
                }

                NextTalk(idx, isSound);
            } 
            else
            {
                //¥Î»≠≥°
                Pee.SetActive(false);
                John.SetActive(false);
                idx = 0;
            }
          
        }
    }

    public void NextTalk(int idx, bool isSound = true)
    {
        if (currTalkList.Count <= idx)
        {
            return;
        }

        DialogData currData = currTalkList[idx];
        if (currData.birdType == EBirdType.Pee)
        {
            Pee.SetActive(true);
            John.SetActive(false);
            peeImg.sprite = peeSpriteList[currData.imgIdx];
            peeText.SetMsg(currData.talkText);
      
            audioSource.clip = peeAudioClip;
        }
        else if (currData.birdType == EBirdType.John)
        {
            John.SetActive(true);
            Pee.SetActive(false);
            johnImg.sprite = johnSpriteList[currData.imgIdx];
            johnText.SetMsg(currData.talkText);
        
            audioSource.clip = johnAudioClip;
        }

        if(isSound)
            audioSource.Play();
     
    }
}

[System.Serializable]
public struct DialogData
{
    public EBirdType birdType;

    public int imgIdx;

    [TextArea(3, 3)]
    public string talkText;
}
