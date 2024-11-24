using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Intacne;
    public AudioMixer _audioMixer;

    public AudioSource _audioSource;
    public Slider _slider;

    public      bool isOn = false;


    private void Awake()
    {
        if(Intacne == null)
        {
            Intacne = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        _audioSource.Play();
    }


    public void AudioControl(float sound)
    {
        _audioSource.volume = sound;
    }

    public void MuteSound()
    {

        if (!isOn)
        {
            _audioSource.mute = true;
            isOn = true;
        }

        else if (isOn)
        {
            _audioSource.mute = false;
            isOn = false;
        }

    }
}
