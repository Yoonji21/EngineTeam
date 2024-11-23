using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithOnOff : MonoBehaviour
{

    private Player  _player;
    private ToadstoolAnim _swithAnim;
    [SerializeField] private Vector2 _checkerSize;
    [SerializeField] private LayerMask _whatIsColorPlayer;
    [SerializeField] private LayerMask _whatIsNoColorPlayer;
    [SerializeField] private GameObject _fkey;
    private AnimationTrigger _animTrigger;
    public bool IsTrggerEnd;

    private void Awake()
    {
        _animTrigger = GetComponentInChildren<AnimationTrigger>();
        _swithAnim = GetComponentInChildren<ToadstoolAnim>();
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

        if (IsTrggerEnd)
        {
            _swithAnim.EndAnimCall();
            IsTrggerEnd = false;
            if(!_player.isSwithOn)
            {
                _player.isSwithOn = true;
            }
            else
            {
                _player.isSwithOn = false;
            }
        }

        if (IsColorPlayerCheck())
        {
            _fkey.SetActive(true);
            _player = GameObject.FindWithTag("ColorPlayer").GetComponent<Player>();
            if (!_player.InputCompo.isAchromatlcEnable || !IsColorPlayerCheck())
            {
                _fkey.SetActive(false);
                _player.IntaractionCompo.OnInteractionEvnets.RemoveAllListeners();
            }
            if (_player.InputCompo.isAchromatlcEnable&&!_swithAnim.isON && !_player.isSwithOn)
            {
              _player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
            }
            if (_swithAnim.isON && _player.InputCompo.isAchromatlcEnable && _player.isSwithOn)
            {
                _player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOff());
            }

        }

        if (IsNoColorPlayerCheck())
        {
            
            _fkey.SetActive(true);
            _player = GameObject.FindWithTag("NoColorPlayer").GetComponent<Player>();
            if (!_player.InputCompo.isChromatlEablbe || !IsNoColorPlayerCheck())
            {
                _fkey.SetActive(false);
                _player.IntaractionCompo.OnInteractionEvnets.RemoveAllListeners();
            }
            if (_player.InputCompo.isChromatlEablbe && !_swithAnim.isON && !_player.isSwithOn)
            {
                _player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
            }
            if (_swithAnim.isON && _player.InputCompo.isChromatlEablbe && _player.isSwithOn)
            {
                _player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOff());
            }

        }
    }

    private void SwithOn()
    {
        _swithAnim.isON = true;
    }

    private void OnSwithAnimEnd()
    {
        IsTrggerEnd = true;
    }

    private void SwithOff()
    {
        _swithAnim.isON = false;
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
    }
}
