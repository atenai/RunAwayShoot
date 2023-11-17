using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip Assult_Sound;
    public AudioClip Reload_Sound;
    public AudioClip BulletEmpty_Sound;
    public AudioClip Switch_sound;
    private AudioSource Master_audioSource;

    bool Bool_Sound = true;

    void Start()
    {
        Master_audioSource = this.gameObject.transform.GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void PlayAssultSound()
    {
        Master_audioSource.PlayOneShot(Assult_Sound);
    }

    public void PlayReloadSound()
    {
        Master_audioSource.PlayOneShot(Reload_Sound);
    }

    public void PlayBulletEmptySound()
    {
        Master_audioSource.PlayOneShot(BulletEmpty_Sound);
    }

    public void PlaySwitchSound()
    {
        Master_audioSource.PlayOneShot(Switch_sound);
    }

    public void StopAudio()
    {
        Master_audioSource.Stop();
    }
}
