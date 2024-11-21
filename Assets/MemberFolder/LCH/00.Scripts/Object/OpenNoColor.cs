using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNoColor : MonoBehaviour 
{
    [SerializeField] private LayerMask _whatIsNoColorPlayer;
    [SerializeField] private Vector2 _chekerSize;
    [SerializeField] private Transform _chekerTrm;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private bool PlayerCheck()
    {
        bool isPlayer = Physics2D.OverlapBox(_chekerTrm.position, _chekerSize, 0, _whatIsNoColorPlayer);
        return isPlayer;
    }

    private void Update()
    {
        if (PlayerCheck())
        {
            UIManager.Intance.isClearNoColor = true;
            _animator.SetBool("Open", true);
        }
        else
        {
            UIManager.Intance.isClearNoColor = false;
            _animator.SetBool("Open", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_chekerTrm.position, _chekerSize);
    }
}
