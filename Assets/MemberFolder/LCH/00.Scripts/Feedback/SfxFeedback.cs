using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SfxFeedback : Feedback
{
    private AudioSource _sfxSource;
    [SerializeField] private AudioClip CurrentClip;
    private AudioManager _audioManager;
    private void OnEnable()
    {
        if (_audioManager == null)
        {
            AudioManager audioManager = new GameObject("AudioManager").AddComponent<AudioManager>();
        }
    }

    public override void PlayFeedback()
    {
        
    }

    public override void StopFeedback()
    {
    }
}
