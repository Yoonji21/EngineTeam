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

    private void MoveObj()
    {
        if (_playerCheck.IsPushObj())
        {
            _rbComp.velocity = new Vector2(_playerCheck.MovementCompo._xMove.x * _playerCheck.MovementCompo._speed, _rbComp.velocity.y);
        }
    }
}
