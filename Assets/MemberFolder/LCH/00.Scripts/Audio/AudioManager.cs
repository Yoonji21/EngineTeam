using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Intacne;
    public AudioMixer _audioMixer;

    public AudioSource _BGMSource;
    public AudioSource _SFXSource;
    //public Slider _slider;

    public bool isOn = false;


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
        _BGMSource.Play();
        _SFXSource.Play();
    }

    public void BGMControl(float sound)
    {
        _BGMSource.volume = sound;
    }
    
    public void SFXControl(float sound)
    {
        _SFXSource.volume = sound;
    }

    public void MuteSound()
    {

        if (!isOn)
        {
            _BGMSource.mute = true;
            _SFXSource.mute = true;
            isOn = true;
        }

        else if (isOn)
        {
            _BGMSource.mute = false;
            _SFXSource.mute = false;
            isOn = false;
        }

    }
}
