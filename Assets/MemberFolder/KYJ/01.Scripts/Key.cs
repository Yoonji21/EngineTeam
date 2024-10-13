using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using 

public class Key : MonoBehaviour
{
    private GameObject _key;
    private GameObject _keyHole;
    private GameObject _barrier;
    private Transform _keyPosition;

    private float _keySpeed = 5f;
    public bool hasKey;
    private bool isHoleHit;

    private void Awake()
    {
        _checkPlayer.OnPlayerCollide += HandlePlayerCollide;
    }

    private void Update()
    {
        if (isHoleHit && hasKey)
        {
            if (Input.GetKeyDown(KeyCode.F))
                OnKeyEnter();
        }
    }

    private void HandlePlayerCollide(string name)
    {
        if (name == "Key")
        {
            _key.transform.DOScale(0.5f, 0.5f);
            hasKey = true;
        }
        else if (name == "KeyHole")
        {
            isHoleHit = true;
        }
    }

    private void FixedUpdate()
    {
        if (hasKey)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        _key.transform.position = Vector3.Lerp
            (_key.transform.position, _keyPosition.position, 0.05f);
    }

    private void OnKeyEnter()
    {
        hasKey = false;

        _key.gameObject.SetActive(false);
        _barrier.gameObject.SetActive(false);
    }
}