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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SwithOnCoroutine());
        }
    }

    private IEnumerator SwithOnCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _player.isSwithOn = true;
        _swithAnim.isON = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_player.isSwithOn)
        {
          
            StartCoroutine(SwithOffCoroutine());
        }
    }

    private IEnumerator SwithOffCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _player.isSwithOn = false;
        _swithAnim.isON = false;
    }
}
