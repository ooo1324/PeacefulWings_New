using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField]
    public GameObject leftBird;
    public GameObject rightBird;
    public GameObject pigeon;

    [HideInInspector]
    public CameraTargetUI cameraTargetUI;

    [HideInInspector]
    public bool isStop = false;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        cameraTargetUI = GetComponent<CameraTargetUI>();
    }

    public void OnDie()
    {    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AllGameData.Current_Init = false;
    }

    public void Clear()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AllGameData.Current_Level += 1;
        AllGameData.Current_Init = true;
    }
}
