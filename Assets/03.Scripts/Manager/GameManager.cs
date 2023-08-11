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

    public AudioClip dieAudio;

    [HideInInspector]
    public CameraTargetUI cameraTargetUI;

    [HideInInspector]
    public bool isStop = false;

    private AudioSource audioSource;
    private bool isDying = false;

    private void Awake()
    {
        instance = this;
        cameraTargetUI = GetComponent<CameraTargetUI>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDie()
    {    
        if(!isDying)
            StartCoroutine(Die());
    }

    public void Clear()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AllGameData.Current_Level += 1;
        AllGameData.Current_Init = true;
    }

    IEnumerator Die()
    {
        isDying = true;
        audioSource.clip = dieAudio;
        audioSource.Play();

        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AllGameData.Current_Init = false;
    }

    public void StopMove()
    {
        isStop = true;
    }

    public void StartMove()
    {
        isStop = false;
    }
}
