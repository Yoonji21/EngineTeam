using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithOnOff : MonoBehaviour
{

    private ToadstoolAnim _swithAnim;

    private void Awake()
    {
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
        _swithAnim.isON = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(SwithOffCoroutine());
    }

    private IEnumerator SwithOffCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _swithAnim.isON = false;
    }
}
