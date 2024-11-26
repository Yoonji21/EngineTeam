using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
	private Animator _animator;
 
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        DontDestroyOnLoad(gameObject);
    }

}
