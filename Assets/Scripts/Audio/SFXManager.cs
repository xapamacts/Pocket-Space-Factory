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

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySliderOn()
    {
        audioSource.PlayOneShot(SliderOn, 1f);
    }

    public void PlaySliderOff()
    {
        audioSource.PlayOneShot(SliderOff, 1f);
    }

    public void PlayStandardClick()
    {
        audioSource.PlayOneShot(StandardClick, 1f);
    }

    public void PlayCloseButton()
    {
        audioSource.PlayOneShot(CloseButton, 1f);
    }
}