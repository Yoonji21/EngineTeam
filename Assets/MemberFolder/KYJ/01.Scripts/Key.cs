using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Key : MonoBehaviour
{
    [SerializeField] private Transform _playerTrm;
    public bool hasKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.transform.SetParent(_playerTrm);
            transform.DOScale(0.5f, 0.5f);
            hasKey = true;
        }
    }

    private void FixedUpdate()
    {
        if (hasKey)
        {
            //FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.Lerp
            (transform.position, _playerTrm.position, 0.05f);
    }

    public void DestroyKey()
    {
        Destroy(gameObject);
    }
}