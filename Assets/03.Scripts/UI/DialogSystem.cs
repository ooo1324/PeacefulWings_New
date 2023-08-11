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

    public Text peeNameText;
    public Text johnNameText;

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
        if (AllGameData.isEng)
        {
            peeNameText.text = "Private 'Pee'";
            johnNameText.text = "Sergeant 'John'";     
        }
        else
        {
            peeNameText.text = "�� �Ϻ�";
            johnNameText.text = "�� ���";
        }
    }

    public void TalkStart(EDialogType key)
    {
        switch (key)
        {
            case EDialogType.start:
                currTalkList = AllGameData.dialogList.start;
                break;
            case EDialogType.sprint:
                currTalkList = AllGameData.dialogList.sprint;
                break;
            case EDialogType.push:
                currTalkList = AllGameData.dialogList.push;
                break;
            case EDialogType.fly:
                currTalkList = AllGameData.dialogList.fly;
                break;
            case EDialogType.flyEnd:
                currTalkList = AllGameData.dialogList.flyEnd;
                break;
            case EDialogType.puzzleStage:
                currTalkList = AllGameData.dialogList.puzzleStage;
                break;
            case EDialogType.goOut:
                currTalkList = AllGameData.dialogList.goOut;
                break;
        }

        if (!panel.activeSelf)
            panel.SetActive(true);

        GameManager.instance.isStop = true;
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
            if(currTalkList == null) { return; }
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
                //��ȭ��
                john_anim.SetInteger("activeType", 0);
                pee_anim.SetInteger("activeType", 0);
                Pee.SetActive(false);
                John.SetActive(false);
                panel.SetActive(false);
                idx = 0;
                isDialogPlay = false;
                GameManager.instance.isStop = false;
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

            peeText.SetMsg(AllGameData.isEng? currData.talkText_eng : currData.talkText_kor);
      
            audioSource.clip = peeAudioClip;
        }
        else if ((EBirdType)currData.birdType == EBirdType.John)
        {
            john_anim.SetInteger("activeType", 1);
            pee_anim.SetInteger("activeType", 2);
            johnImg.sprite = johnSpriteList[currData.imgIdx];
            johnText.SetMsg(AllGameData.isEng ? currData.talkText_eng : currData.talkText_kor);
        
            audioSource.clip = johnAudioClip;
        }

        if(isSound)
            audioSource.Play();
     
    }
}

