using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Intacne;
    public AudioMixer _audioMixer;

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
    }

    public void MuteSound()
    {
        _audioMixer.SetFloat("Master", -80f);
    }
}
