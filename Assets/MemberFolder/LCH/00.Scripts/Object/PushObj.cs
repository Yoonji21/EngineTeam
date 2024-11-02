using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObj : MonoBehaviour
{
	private Rigidbody2D _rbComp;
    private Player _playerCheck;

    private void Awake()
    {
        _rbComp = GetComponent<Rigidbody2D>();
        _playerCheck = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (!_playerCheck.IsPushObj())
        {
            _rbComp.velocity = new Vector2(0,_rbComp.velocity.y);
        }
    }
}
