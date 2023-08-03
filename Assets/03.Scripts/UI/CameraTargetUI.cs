using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetUI : MonoBehaviour
{
    public GameObject john_camera;
    public GameObject Pee_camera;

    public void Ative_John()
    {
        john_camera.SetActive(true);
        Pee_camera.SetActive(false);
    }

    public void Active_Pee()
    {
        john_camera.SetActive(false);
        Pee_camera.SetActive(true);
    }

    public void Active_Pegeon()
    {
        john_camera.SetActive(false);
        Pee_camera.SetActive(false);
    }
}
