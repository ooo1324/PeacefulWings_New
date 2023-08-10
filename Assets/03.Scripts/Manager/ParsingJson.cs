using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ParsingJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (AllGameData.dialogList != null) return;
        TextAsset textAsset = Resources.Load<TextAsset>("DialogData");

        AllGameData.dialogList = JsonUtility.FromJson<DialogList>(textAsset.text);

        foreach (EDialogType dialogType in System.Enum.GetValues(typeof(EDialogType)))
        {
            AllGameData.dialogFlagList[dialogType] = false;
        }
    }
}

[System.Serializable]
public struct DialogData
{
    public int birdType;

    public int imgIdx;

    [TextArea(3, 3)]
    public string talkText_kor;

    [TextArea(3, 3)]
    public string talkText_eng;
}

[System.Serializable]
public class DialogList
{
    public List<DialogData> start;
    public List<DialogData> sprint;
    public List<DialogData> push;
    public List<DialogData> fly;
    public List<DialogData> flyEnd;
    public List<DialogData> end;
}

public enum EDialogType
{
    start,
    sprint,
    push,
    fly,
    flyEnd,
    end
}
