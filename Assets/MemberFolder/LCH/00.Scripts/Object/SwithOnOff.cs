using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithOnOff : MonoBehaviour
{

    public Player  _Player;
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
            Debug.Log(_Player.isSwithOn);
        }

        if (IsColorPlayerCheck())
        {
            _fkey.SetActive(true);
            _Player = GameObject.FindWithTag("ColorPlayer").GetComponent<Player>();
            _Player.isSwithingPlayer = false;
            if (_Player.InputCompo.isAchromatlcEnable&&!_swithAnim.isON && !_Player.isSwithOn)
            {
              _Player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
            }
            if (_swithAnim.isON && _Player.InputCompo.isAchromatlcEnable && _Player.isSwithOn)
            {
                _Player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOff());
            }

        }

        if (IsNoColorPlayerCheck())
        {
            
            _fkey.SetActive(true);
            _Player = GameObject.FindWithTag("NoColorPlayer").GetComponent<Player>();
            _Player.isSwithingPlayer = false;
            if (_Player.InputCompo.isChromatlEablbe && !_swithAnim.isON && !_Player.isSwithOn)
            {
                _Player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
            }
            if (_swithAnim.isON && _Player.InputCompo.isChromatlEablbe && _Player.isSwithOn)
            {
                _Player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOff());
            }

        }

        if(!IsNoColorPlayerCheck() && !IsColorPlayerCheck())
        {
            _fkey.SetActive(false);
            _Player = GameObject.FindWithTag("NoColorPlayer").GetComponent<Player>();
            if (_Player.InputCompo.isChromatlEablbe)
            {
                _Player.isSwithingPlayer = true;
            }
            else 
            {
                _Player = GameObject.FindWithTag("ColorPlayer").GetComponent<Player>();
                if (_Player.InputCompo.isAchromatlcEnable)
                {
                    _Player.isSwithingPlayer = true;
                }
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
