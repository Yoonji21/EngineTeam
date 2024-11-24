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
    private Animator _animator;
    public bool IsTrggerEnd;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
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
            if (_Player.InputCompo.isAchromatlcEnable && !_swithAnim.isON)
            {
                _Player.IntaractionCompo.OnInteractionEvnets.RemoveAllListeners();
                _Player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
            }
            if(_Player.InputCompo.isAchromatlcEnable && _swithAnim.isON)
            {
                _Player.IntaractionCompo.OnInteractionEvnets.RemoveAllListeners();
                _Player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOff());
            }

        }

        if (IsNoColorPlayerCheck())
        {

            _fkey.SetActive(true);
            _Player = GameObject.FindWithTag("NoColorPlayer").GetComponent<Player>();
            _Player.isSwithingPlayer = false;
            if (_Player.InputCompo.isChromatlEablbe && !_swithAnim.isON)
            {
                _Player.IntaractionCompo.OnInteractionEvnets.RemoveAllListeners();
                _Player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
            }
            if(_Player.InputCompo.isChromatlEablbe && _swithAnim.isON)
            {
                _Player.IntaractionCompo.OnInteractionEvnets.RemoveAllListeners();
                _Player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOff());
            }
        }

        if (!IsNoColorPlayerCheck())
        {
            _fkey.SetActive(false);
            _Player = GameObject.FindWithTag("NoColorPlayer").GetComponent<Player>();
            if (_Player.InputCompo.isChromatlEablbe && _swithAnim)
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
                if (_swithAnim.isON)
                {
                    _Player.IntaractionCompo.OnInteractionEvnets.RemoveListener(() => SwithOn());
                }
                else
                {
                    _Player.IntaractionCompo.OnInteractionEvnets.RemoveListener(() => SwithOff());
                }
            }
        }
    }

    private void SwithOn()
    {
        _animator.SetBool("ON",true);
    }

    private void SwithOff()
    {
        _swithAnim.isON = false;
        _animator.SetBool("ON", false);
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