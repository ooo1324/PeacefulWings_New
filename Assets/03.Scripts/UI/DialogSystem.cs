using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
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
    public GameObject panel;

    private int idx;

    private Animator pee_anim;
    private Animator john_anim;

    private List<DialogData> currTalkList;
    private AudioSource audioSource;
    private bool isDialogPlay = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        pee_anim = Pee.GetComponent<Animator>();
        john_anim = John.GetComponent<Animator>();
    }

    private void Start()
    {
        idx = 0;
    }

    public void TalkStart(EDialogType key)
    {
        switch (key)
        {
            case EDialogType.start:
                currTalkList = ParsingJson.dialogList.start;
                break;
            case EDialogType.sprint:
                currTalkList = ParsingJson.dialogList.sprint;
                break;
            case EDialogType.push:
                currTalkList = ParsingJson.dialogList.push;
                break;
            case EDialogType.fly:
                currTalkList = ParsingJson.dialogList.fly;
                break;
            case EDialogType.flyEnd:
                currTalkList = ParsingJson.dialogList.flyEnd;
                break;
            case EDialogType.end:
                currTalkList = ParsingJson.dialogList.end;
                break;
        }

        if (!panel.activeSelf)
            panel.SetActive(true);

        Pee.SetActive(true);
        John.SetActive(true);
        john_anim.SetInteger("activeType", 2);
        pee_anim.SetInteger("activeType", 2);
        isDialogPlay = true;
        NextTalk(idx, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currTalkList.Count > idx)
            {
                if (!isDialogPlay) return;
                bool isSound = false;
                if ((EBirdType)currTalkList[idx].birdType == EBirdType.Pee)
                {
                    if (!peeText.isAnimation)
                    {
                        idx++;
                        isSound = true;
                    }
                }
                else if ((EBirdType)currTalkList[idx].birdType == EBirdType.John)
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
                john_anim.SetInteger("activeType", 0);
                pee_anim.SetInteger("activeType", 0);
                Pee.SetActive(false);
                John.SetActive(false);
                panel.SetActive(false);
                idx = 0;
                isDialogPlay = false;
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

        if ((EBirdType)currData.birdType == EBirdType.Pee)
        {
            john_anim.SetInteger("activeType", 2);
            pee_anim.SetInteger("activeType", 1);
            peeImg.sprite = peeSpriteList[currData.imgIdx];
            peeText.SetMsg(currData.talkText_kor);
      
            audioSource.clip = peeAudioClip;
        }
        else if ((EBirdType)currData.birdType == EBirdType.John)
        {
            john_anim.SetInteger("activeType", 1);
            pee_anim.SetInteger("activeType", 2);
            johnImg.sprite = johnSpriteList[currData.imgIdx];
            johnText.SetMsg(currData.talkText_kor);
        
            audioSource.clip = johnAudioClip;
        }

        if(isSound)
            audioSource.Play();
     
    }
}

