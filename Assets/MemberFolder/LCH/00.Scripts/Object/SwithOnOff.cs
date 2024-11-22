using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithOnOff : MonoBehaviour
{

    private Player  _player;
    private ToadstoolAnim _swithAnim;
    private BoxCollider2D _playerTrigger;
    [SerializeField] private Vector2 _checkerSize;
    [SerializeField] private LayerMask _whatIsColorPlayer;
    [SerializeField] private LayerMask _whatIsNoColorPlayer;
    [SerializeField] private GameObject _fkey;
    private AnimationTrigger _animTrigger;
    private bool _isTrggerEnd;

    private void Awake()
    {
        _animTrigger = GetComponentInChildren<AnimationTrigger>();
        _swithAnim = GetComponentInChildren<ToadstoolAnim>();
        _playerTrigger = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        _animTrigger.OnAnimationEnd += OnSwithAnimEnd;
    }

    private void OnDestroy()
    {
        _animTrigger.OnAnimationEnd -= OnSwithAnimEnd;
    }

    private bool IsColorPlayerCheck()
    {
        bool isPlayer = Physics2D.OverlapBox(transform.position, _checkerSize, 0, _whatIsColorPlayer);
        return isPlayer;
    }

    private bool IsNoColorPlayerCheck()
    {
        bool isPlayer = Physics2D.OverlapBox(transform.position, _checkerSize, 0, _whatIsNoColorPlayer);
        return isPlayer;
    }

    private void Update()
    {

        if (_isTrggerEnd)
        {
            _player.isSwithOn = true;
            _playerTrigger.enabled = false;
            _fkey.SetActive(false);
            _swithAnim.EndAnimCall();
        }

        if (IsColorPlayerCheck())
        {
            _fkey.SetActive(true);
            _player = GameObject.FindWithTag("ColorPlayer").GetComponent<Player>();
            _player.isSwithingPlayer = false;
              _player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
        }

        if (IsNoColorPlayerCheck())
        {
            
            _fkey.SetActive(true);
            _player = GameObject.FindWithTag("NoColorPlayer").GetComponent<Player>();
            _player.isSwithingPlayer = false;
            _player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
        }

        if (!IsColorPlayerCheck() && !IsNoColorPlayerCheck())
        {
            _fkey.SetActive(false);
            if (_swithAnim.isON)
            {
                _player.isSwithingPlayer = true;
                  _player.IntaractionCompo.OnInteractionEvnets.RemoveAllListeners();   
                StartCoroutine(SwithOffCoroutine());
            }
        }

      

    }

    private void SwithOn()
    {
        _swithAnim.isON = true;
    }

    private void OnSwithAnimEnd()
    {
        _isTrggerEnd = true;
    }

    private IEnumerator SwithOffCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _swithAnim.isON = false;
        _player.isSwithOn = false;
        _playerTrigger.enabled = true;
        _isTrggerEnd = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
    }
}
