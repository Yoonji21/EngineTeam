using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator _animator;
    private AnimationTrigger _animTrigger;
    private bool _isEndTrigger = false;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _animTrigger = GetComponentInChildren<AnimationTrigger>();
    }

    private void OnEnable()
    {
        _animTrigger.OnAnimationEnd += AnimEndTrigger;
    }

    private void OnDestroy()
    {
        _animTrigger.OnAnimationEnd -= AnimEndTrigger;
    }

    private void Update()
    {
        if (_isEndTrigger)
        {
            _isEndTrigger = false;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Key key = collision.gameObject.GetComponent<Key>();

            if (collision.gameObject.CompareTag("Key"))
            {
                key.DestroyKey();

                _animator.SetBool("Open", true);
                print("open");
            }

    }

    private void AnimEndTrigger()
    {
        _isEndTrigger = true;
    }
}
