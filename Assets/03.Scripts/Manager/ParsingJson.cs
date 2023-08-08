using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ParsingJson : MonoBehaviour
{
    [HideInInspector]
    public static DialogList dialogList;

    // Start is called before the first frame update
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("DialogData");

        dialogList = JsonUtility.FromJson<DialogList>(textAsset.text);
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
