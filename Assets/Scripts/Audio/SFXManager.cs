using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip SliderOn;
    public AudioClip SliderOff;
    public AudioClip StandardClick;
    public AudioClip CloseButton;

    private AudioSource audioSource;

    void Awake()
    { 
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySliderOn()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(SliderOn, 1f);
        }
    }

    public void PlaySliderOff()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(SliderOff, 1f);
        }  
    }

    public void PlayStandardClick()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(StandardClick, 1f);
        }
            
    }

    public void PlayCloseButton()
    {
        if (Global.canSFXPlay == true)
        {
            audioSource.PlayOneShot(CloseButton, 1f);
        }   
    }
}