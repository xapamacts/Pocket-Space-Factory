using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    public AudioClip menuMusic;
    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMenuSoundtrack()
    {
        audioSource.clip = menuMusic;
        if (Global.canAudioPlay == true)
        {
            audioSource.Play();
        }
    }

    public void StopMenuSoundtrack()
    {
        audioSource.Stop();
    }
}

