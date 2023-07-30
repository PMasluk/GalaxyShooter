using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource effectSource;
    [SerializeField]
    private AudioClip music1;
    [SerializeField]
    private AudioClip effect1;
    [SerializeField]
    private AudioClip effect2;

    public void PlayShotEffect()
    {
        effectSource.PlayOneShot(effect1);
    }

    public void PlayDestroyEffect()
    {
        effectSource.PlayOneShot(effect2);
    }
}
