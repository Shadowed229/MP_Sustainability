using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            Debug.Log("randal is gay");
        }
    }

}
