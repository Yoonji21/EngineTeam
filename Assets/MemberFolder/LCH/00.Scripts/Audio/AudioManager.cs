using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Intacne;
    public AudioMixer _audioMixer;

    public AudioSource _BGMSource;
    public AudioSource _SFXSource;
    private Animator _currentAnimator;
    private BtnAnim _animTrigger;

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
        
        _BGMSource.Play();
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
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponent<Animator>();
        _animTrigger = EventSystem.current.currentSelectedGameObject.GetComponent<BtnAnim>();
        _currentAnimator.SetBool("IsClik", true);
        _animTrigger.Anim = _currentAnimator;
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
