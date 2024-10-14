using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Vector2 _checkerSize;
    private Rigidbody2D _rbcompo;
    private Vector3 _xMove;

    private void Awake()
    {
        _rbcompo = GetComponent<Rigidbody2D>();
    }

    private bool GroundChecker()
    {
        bool isGround = Physics2D.OverlapBox(_groundChecker.position, _checkerSize, 0, _whatIsGround);
        return isGround;
    }

    public void GetJump()
    {
        if (GroundChecker())
        {
            _rbcompo.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    public void GetMove(Vector2 value)
    {
        _xMove.x = value.x;
    }

    private void FixedUpdate()
    {
        _rbcompo.velocity = new Vector2(_xMove.x * _speed, _rbcompo.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundChecker.position, _checkerSize);
    }
}
