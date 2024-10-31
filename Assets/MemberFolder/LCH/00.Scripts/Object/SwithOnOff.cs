using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithOnOff : MonoBehaviour
{

    private Player _player;
    private ToadstoolAnim _swithAnim;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _swithAnim = GetComponentInChildren<ToadstoolAnim>();
    }

    private void Update()
    {
        if (_player.IsToadstoolObj())
        {
            StartCoroutine(SwithOnCoroutine());
        }
        if (!_player.IsToadstoolObj())
        {
            if (_player.isSwithOn)
            {
                StartCoroutine(SwithOffCoroutine());
            }
        }
    }

    private IEnumerator SwithOnCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _player.isSwithOn = true;
        _swithAnim.isON = true;
    }

    private IEnumerator SwithOffCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _player.isSwithOn = false;
        _swithAnim.isON = false;
    }
}
