using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
	private Animator _animator;
    private AnimationTrigger _trigger;

    private bool _isEndTrigger;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _trigger = GetComponentInChildren<AnimationTrigger>();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (_isEndTrigger)
        {
            _animator.SetBool("PopUp", false);
            _isEndTrigger = false;
        }
        if (UIManager.Intance.PopUpOn)
        { 
            _animator.SetBool("PopUp", true);
        }
    }

    private void OnEnable()
    {
        _trigger.OnAnimationEnd += EndAnim;
    }

    private void OnDisable()
    {
        _trigger.OnAnimationEnd -= EndAnim;
    }

    private void EndAnim()
    {
        _isEndTrigger = true;
    }
}
