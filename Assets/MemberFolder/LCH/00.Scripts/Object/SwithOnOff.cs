using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithOnOff : MonoBehaviour
{

    public Player _Player;
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
        }

        if (IsColorPlayerCheck())
        {
            _fkey.SetActive(true);
            _Player = GameObject.FindWithTag("ColorPlayer").GetComponent<Player>();
            _Player.isSwithingPlayer = false;
            if (_Player.InputCompo.isAchromatlcEnable)
            {
                _Player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
            }

        }

        if (IsNoColorPlayerCheck())
        {

            _fkey.SetActive(true);
            _Player = GameObject.FindWithTag("NoColorPlayer").GetComponent<Player>();
            _Player.isSwithingPlayer = false;
            if (_Player.InputCompo.isChromatlEablbe)
            {
                _Player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
            }
        }

        if (!IsNoColorPlayerCheck())
        {
            _fkey.SetActive(false);
            _Player = GameObject.FindWithTag("NoColorPlayer").GetComponent<Player>();
            if (_Player.InputCompo.isChromatlEablbe)
            {
                _Player.isSwithingPlayer = true;
                _Player.IntaractionCompo.OnInteractionEvnets.RemoveListener(() => SwithOn());
            }
            else
            {
                _Player.IntaractionCompo.OnInteractionEvnets.RemoveListener(() => SwithOn());
            }
        }
        if (!IsColorPlayerCheck())
        {
            _fkey.SetActive(false);
            _Player = GameObject.FindWithTag("ColorPlayer").GetComponent<Player>();
            if (_Player.InputCompo.isAchromatlcEnable)
            {
                _Player.isSwithingPlayer = true;
                _Player.IntaractionCompo.OnInteractionEvnets.RemoveListener(() => SwithOn());
            }
            else
            {
                _Player.IntaractionCompo.OnInteractionEvnets.RemoveListener(() => SwithOn());
            }
        }
    }

    private void SwithOn()
    {
        if(!_swithAnim.isON && !_Player.isSwithOn)
        {
            _swithAnim.isON = true;
        }
        if (_swithAnim.isON&&_Player.isSwithOn)
        {
            _swithAnim.isON = false;
        }
        if (!_Player.isSwithOn && _swithAnim.isON)
        {
            _Player.isSwithOn = true;         
        }
        if (_Player.isSwithOn && !_swithAnim.isON)
        {
            _Player.isSwithOn = false;
        }
    }

    private void OnSwithAnimEnd()
    {
        IsTrggerEnd = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
    }
}