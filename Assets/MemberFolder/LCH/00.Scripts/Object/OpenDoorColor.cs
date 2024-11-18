using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorColor : MonoBehaviour
{

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Achromatic achromatic))
        {
            _animator.SetBool("Open", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _animator.SetBool("Open", false);
    }
}
