using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetUI : MonoBehaviour
{
    public GameObject john_camera;
    public GameObject pee_camera;
    public GameObject john_Navi;
    public GameObject pee_navi;

    public void Ative_John()
    {
        john_camera.SetActive(true);
        pee_camera.SetActive(false);
        john_Navi.SetActive(false);
        pee_navi.SetActive(true);
    }

    public void Active_Pee()
    {
        john_camera.SetActive(false);
        pee_camera.SetActive(true);
        john_Navi.SetActive(true);
        pee_navi.SetActive(false);
    }

    public void Active_Pegeon()
    {
        john_camera.SetActive(false);
        pee_camera.SetActive(false);
        john_Navi.SetActive(false);
        pee_navi.SetActive(false);
    }
}
