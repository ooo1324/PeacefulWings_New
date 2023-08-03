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

    private void Awake()
    {
        instance = this;
        cameraTargetUI = GetComponent<CameraTargetUI>();
    }


    public void OnDie()
    {
        SceneManager.LoadScene("Level2Scene");
    }
}
