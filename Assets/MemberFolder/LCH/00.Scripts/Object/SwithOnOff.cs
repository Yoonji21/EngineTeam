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
    [SerializeField] private LayerMask _whatIsPlayer;

    private void Awake()
    {
        _swithAnim = GetComponentInChildren<ToadstoolAnim>();
        _playerTrigger = GetComponent<BoxCollider2D>();
    }

    public bool IsPlayerCheck()
    {
        bool isPlayer = Physics2D.OverlapBox(transform.position, _checkerSize, 0, _whatIsPlayer);
        return isPlayer;
    }

    private void Update()
    {
        if (IsPlayerCheck())
        {
            _player = GameObject.FindWithTag("Player").GetComponent<Player>();
            _player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
        }

        if (!IsPlayerCheck()&&_swithAnim.isON)
        {
             _player = GameObject.FindWithTag("Player").GetComponent<Player>();
           StartCoroutine(SwithOffCoroutine());
        }

    }

    private void SwithOn()
    {
        _swithAnim.isON = true;
        _playerTrigger.enabled = false;
    }

    private IEnumerator SwithOffCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _player.IntaractionCompo.OnInteractionEvnets.RemoveAllListeners();
        _swithAnim.isON = false;
        _playerTrigger.enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
    }
}
