using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNoColor : MonoBehaviour 
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ChromatiColor chromatiColor))
        {
            if (chromatiColor != null)
            {
                UIManager.Intance.isClearNoColor = true;
                _animator.SetBool("Open", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ChromatiColor chromatiColor))
        {
            UIManager.Intance.isClearNoColor = false;
            _animator.SetBool("Open", false);
        }
    }
}
