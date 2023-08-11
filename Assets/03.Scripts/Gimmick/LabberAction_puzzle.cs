using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class LabberAction_puzzle : MonoBehaviour
{
    [HideInInspector]
    public enum ELabberType
    {
        OneLabber,
        TwoLabber
    }

    public ELabberType LbSystemType;
    //public GameObject actionObject;
    public GameObject LabberObject;

    public LightBeamController[] beams;
    public int direction;

    public float delayTime = 0.5f;

    bool isLabber = false;
    bool isAction = false;
    public TwoLabberAction_puzzle twoladderAction;
    GameObject actionBird;
    PlayerController playerController;
    private AudioSource audioSource;
    public bool isLeverOpen = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        LightBeamCheck.onOpenDoorEvent.AddListener(OpenDoorEventFunc);
    }

    private void OpenDoorEventFunc(bool isOpen)
    {
        isLeverOpen = true;
    }

    public void OnRightLabber(InputValue value)
    {
        if (isLeverOpen) return;
        if (isAction) return;
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
                             StartCoroutine(LabberActiveAction());
                        }
                    }
                }
                else
                {
                        StartCoroutine(LabberActiveAction());
                }
            }
        }
    }

    public void OnLeftLabber(InputValue value)
    {
        if (isLeverOpen) return;
        if (isAction) return;
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
                                StartCoroutine(LabberActiveAction());
                        }
                    }
                }
                else
                {
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
                //twoladderAction = actionObject.GetComponent<TwoLabberAction>();
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
                //twoladderAction = actionObject.GetComponent<TwoLabberAction>();
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
        if (isAction) yield return null;
        playerController.LabberAction(gameObject.transform);
        isAction = true;
        LabberObject.SetActive(false);
        audioSource.Play();
        yield return new WaitForSeconds(delayTime);
    
        if (LbSystemType == ELabberType.OneLabber)
        {
            //actionObject.SetActive(true);

            foreach (LightBeamController beam in beams)
            {
                beam.RotateLightBeam(direction);
            }
        }
        else
        {
            twoladderAction.CompleteAction(playerController.birdType);
        }

        LabberObject.SetActive(true);
        isAction = false;
    }
}
