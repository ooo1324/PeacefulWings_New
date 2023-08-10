using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameData : MonoBehaviour
{
    public static int Current_Level = 0;
    public static bool Current_Init = true;
    public static bool isEng = false;
    public static Dictionary<EDialogType, bool> dialogFlagList = new Dictionary<EDialogType, bool>();

    [HideInInspector]
    public static DialogList dialogList;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
