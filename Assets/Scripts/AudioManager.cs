using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    private void Update()
    {
        if (!audioSource.isPlaying && LevelManager.instance.isPaused == false && LevelManager.instance.isGameOver == false)
        {
            audioSource.Play();
            
        }
        if(LevelManager.instance.isPaused == true)
        {
            audioSource.Stop();
        }
    }

}
