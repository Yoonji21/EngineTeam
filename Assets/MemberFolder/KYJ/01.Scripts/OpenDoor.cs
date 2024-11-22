using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Key key = collision.gameObject.GetComponentInChildren<Key>();

        if (key != null)
        {
            if (key.hasKey)
            {
                key.hasKey = false;
                _boxCollider.enabled = false;
                key.DestroyKey();

                _animator.SetBool("Open", true);
            }
        }

        else
        {
            _boxCollider.enabled = true;
        }
    }
}
