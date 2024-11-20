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
    [SerializeField] private GameObject _fkey;

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
            _fkey.SetActive(true);
            var p = GameObject.FindWithTag("Player").GetComponents<Player>();
            foreach(var player in p)
            {
                if (player.gameObject.activeSelf)
                {
                    Debug.Log(player.name);
                    player.IntaractionCompo.OnInteractionEvnets.AddListener(() => SwithOn());
                    break;
                }
            }
        }

        if (!IsPlayerCheck())
        {
            _fkey.SetActive(false);
            if (_swithAnim.isON)
            {
                var p = GameObject.FindWithTag("Player").GetComponents<Player>();
                foreach(var player in p)
                {
                    if (!player.gameObject.activeSelf)
                    {
                        player.IntaractionCompo.OnInteractionEvnets.RemoveAllListeners();
                    }
                }
                StartCoroutine(SwithOffCoroutine());
            }
        }

    }

    private void SwithOn()
    {
        _swithAnim.isON = true;
        _playerTrigger.enabled = false;
        _fkey.SetActive(false);
    }

    private IEnumerator SwithOffCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _swithAnim.isON = false;
        _playerTrigger.enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
    }
}
