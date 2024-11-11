using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithOnOff : MonoBehaviour
{

    private Player _player;
    private ToadstoolAnim _swithAnim;
    private BoxCollider2D _playerTrigger;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _swithAnim = GetComponentInChildren<ToadstoolAnim>();
        _playerTrigger = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (_player.IsToadstoolObj())
        {
            StartCoroutine(SwithOnCoroutine());
        }
        if (!_player.IsToadstoolObj())
        {
           StartCoroutine(SwithOffCoroutine());
        }
    }

    private IEnumerator SwithOnCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _swithAnim.isON = true;
        _playerTrigger.enabled = false;
    }

    private IEnumerator SwithOffCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _swithAnim.isON = false;
        _playerTrigger.enabled = true;
    }
}
