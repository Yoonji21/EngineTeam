using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoldObject : MonoBehaviour
{

    public UnityEvent OnHoldEvent;

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
        if (_player.IsHoldObj())
        {
            _player.IntaractionCompo.OnInteractionEvnets.AddListener(() => HoldObjCall());
        }
    }

    public void HoldObjCall()
    {
        transform.position = _holdPos.position;
        _rbCompo.velocity = new Vector2(_player.MovementCompo._xMove.x * _player.MovementCompo._speed, _rbCompo.velocity.y);
    }
}
