using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public Dictionary<string, List<DialogData>> talkDic;
    public List<Sprite> peeSpriteList;
    public List<Sprite> johnSpriteList;
    public TextEffect peeText;
    public TextEffect johnText;
    public Image peeImg;
    public Image johnImg;
    public AudioClip peeAudioClip;
    public AudioClip johnAudioClip;

    private List<DialogData> currTalkList;

    public void TalkStart(string key)
    {
        currTalkList = talkDic[key];
        NextTalk(0);
    }

    public void NextTalk(int idx)
    {
        if (currTalkList.Count > idx)
        {
            DialogData currData = currTalkList[idx];

            if (currData.birdType == EBirdType.Pee)
            {
                
                peeText.SetMsg(currData.talkText);
            }
            else if (currData.birdType == EBirdType.John)
            {
                
            }
        }
        else
        {
            //¥Î»≠≥°
        }
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
