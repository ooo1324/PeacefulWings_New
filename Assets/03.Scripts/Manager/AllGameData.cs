using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameData : MonoBehaviour
{
    public static int Current_Level = 0;
    public static bool Current_Init = true;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
