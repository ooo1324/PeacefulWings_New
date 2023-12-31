using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;


public class CameraShake : MonoBehaviour
{
    public float ShakeDuration = 0.3f;          // Time the Camera Shake effect will last
    public float ShakeAmplitude = 2f;         // Cinemachine Noise Profile Parameter
    public float ShakeFrequency = 1.7f;         // Cinemachine Noise Profile Parameter

    private float ShakeElapsedTime = 0f;
    private AudioSource audioSource;

    // Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    private bool isPlay = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start()
    {
        // Get Virtual Camera Noise Profile
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }



    // Update is called once per frame
    void Update()
    {

        // TODO: Replace with your trigger
        if (isPlay)
        {
            ShakeElapsedTime = ShakeDuration;
        }
        else
        {
            if(audioSource != null)
                if (audioSource.isPlaying)
                    audioSource.Stop();
        }


        // If the Cinemachine componet is not set, avoid update
        if (VirtualCamera != null && virtualCameraNoise != null)
        {
            // If Camera Shake effect is still playing
            if (ShakeElapsedTime > 0)
            {
                if (audioSource != null)
                    if (!audioSource.isPlaying)
                        audioSource.Play();
                // Set Cinemachine Camera Noise parameters
                virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = ShakeFrequency;

                // Update Shake Timer
                ShakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                // If Camera Shake effect is over, reset variables
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }

    }

    public void PlayShake()
    {
        isPlay = true;
    }

    public void StopShake()
    {
        isPlay = false;
    }

}
