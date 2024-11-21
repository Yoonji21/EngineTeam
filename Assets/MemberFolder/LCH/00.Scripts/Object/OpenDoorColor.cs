using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorColor : MonoBehaviour
{

    [SerializeField] private LayerMask _whatIsColorPlayer;
    [SerializeField] private Vector2 _chekerSize;
    [SerializeField] private Transform _chekerTrm;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private bool PlayerCheck()
    {
        bool isPlayer = Physics2D.OverlapBox(_chekerTrm.position, _chekerSize, 0, _whatIsColorPlayer);
        return isPlayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Achromatic achromatic))
        {
          
            if (achromatic != null)
            {
                UIManager.Intance.isClearColor = true;
                _animator.SetBool("Open", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Achromatic achromatic))
        {
            UIManager.Intance.isClearColor = false;
            _animator.SetBool("Open", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_chekerTrm.position, _chekerSize);
    }
}
