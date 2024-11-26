using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
	private Animator _animator;
 
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (UIManager.Intance.PopUpOn)
        {
            _animator.SetBool("PopUp", true);
        }
        else
        {
            _animator.SetBool("PopUp", false);
        }
    }

}
