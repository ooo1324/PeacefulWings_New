using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class LabberAction : MonoBehaviour
{
    [HideInInspector]
    public enum ELabberType
    {
        OneLabber,
        TwoLabber
    }

    public ELabberType LbSystemType;
    public GameObject actionObject;
    public GameObject LabberObject;
    public float delayTime = 0.5f;
    public PlayableDirector playableDirector; 

    bool isLabber = false;
    private bool isInit = false;
    private TwoLabberAction twoladderAction;
    GameObject actionBird;
    PlayerController playerController;
    private AudioSource audioSource;
    private bool isAnimPlay = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnRightLabber(InputValue value)
    {
        if (isLabber)
        {
            if (playerController.birdType == EBirdType.John)
            {
                if (LbSystemType == ELabberType.TwoLabber)
                {
                    if (twoladderAction != null)
                    {
                        if (twoladderAction.firstLabber && twoladderAction.secondLabber)
                        {
                            if(!isInit)
                             StartCoroutine(LabberActiveAction());
                        }
                    }
                }
                else
                {
                    if (!isInit)
                        StartCoroutine(LabberActiveAction());
                }
            }
        }
    }

    public void OnLeftLabber(InputValue value)
    {
        if (isLabber)
        {
            if (playerController.birdType == EBirdType.Pee)
            {
                if (LbSystemType == ELabberType.TwoLabber)
                {
                    if (twoladderAction != null)
                    {
                        if (twoladderAction.firstLabber && twoladderAction.secondLabber)
                        {
                            if (!isInit)
                                StartCoroutine(LabberActiveAction());
                        }
                    }
                }
                else
                {
                    if (!isInit)
                        StartCoroutine(LabberActiveAction());
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            actionBird = collision.gameObject;
            playerController = actionBird.GetComponent<PlayerController>();
            isLabber = true;

            if (LbSystemType == ELabberType.TwoLabber)
            {
                twoladderAction = actionObject.GetComponent<TwoLabberAction>();
                if (playerController.birdType == EBirdType.Pee)
                {      
                    twoladderAction.firstLabber = true;
                }
                if (playerController.birdType == EBirdType.John)
                {
                    twoladderAction.secondLabber = true;
                }
            }
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isLabber = false;

            if (LbSystemType == ELabberType.TwoLabber)
            {
                twoladderAction = actionObject.GetComponent<TwoLabberAction>();
                if (playerController.birdType == EBirdType.Pee)
                {
                    twoladderAction.firstLabber = false;
                }
                if (playerController.birdType == EBirdType.John)
                {
                    twoladderAction.secondLabber = false;
                }
            }
        }
    }

    IEnumerator LabberActiveAction()
    {
        if (isAnimPlay) yield return null;

        isAnimPlay = true;
        LabberObject.SetActive(false);
        audioSource.Play();
        playerController.LabberAction(gameObject.transform);
        yield return new WaitForSeconds(delayTime);
    
        if (LbSystemType == ELabberType.OneLabber)
        {
            isInit = true;
            actionObject.SetActive(true);
            if (playableDirector != null)
            {
                playableDirector.gameObject.SetActive(true);
                playableDirector.Play();
            }
        }
        else
        {
            twoladderAction.CompleteAction(playerController.birdType);
        }

        LabberObject.SetActive(true);
        isAnimPlay = false;
    }
}
