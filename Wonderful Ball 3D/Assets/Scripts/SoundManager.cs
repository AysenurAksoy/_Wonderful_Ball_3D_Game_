using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource buttonSource;
    public AudioSource blowupSource;
    public AudioSource cashSource;
    public AudioSource completeSource;
    public AudioSource objecthitSource;

    public AudioClip buttonClip;
    public AudioClip blowupClip;
    public AudioClip cashClip;
    public AudioClip completeClip;
    public AudioClip objecthitClip;

    public void ButtonSound()
    {
        buttonSource.PlayOneShot(buttonClip);
    }

    public void BlowupSound()
    {
        blowupSource.PlayOneShot(blowupClip, 0.3f);
    }
    public void CashSound()
    {
        cashSource.PlayOneShot(cashClip);
    }

    public void CompleteSound()
    {
        completeSource.PlayOneShot(completeClip);
    }

    public void objecthitSound()
    {
        objecthitSource.PlayOneShot(objecthitClip);
    }
}
