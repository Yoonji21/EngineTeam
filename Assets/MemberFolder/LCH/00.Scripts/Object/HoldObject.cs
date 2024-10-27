using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    private Rigidbody2D _rbCompo;
    private Transform _holdPos;
	private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _holdPos = GameObject.Find("HoldPos").transform;
        _rbCompo = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HoldObjCall();
    }

    public void HoldObjCall()
    {
        if (_player.IsHoldObj())
        {
            transform.position = _holdPos.position;
            _rbCompo.velocity = new Vector2(_player.MovementCompo._xMove.x * _player.MovementCompo._speed, _rbCompo.velocity.y);
        }
    }
}
