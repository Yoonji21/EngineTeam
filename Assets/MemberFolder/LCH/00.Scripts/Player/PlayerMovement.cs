using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [field:SerializeField] public float _speed;
    private Rigidbody2D _rbcompo;
    public Vector3 _xMove;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Vector2 _checkerSize;
    public bool IsGrounded { get; private set; }
    private float _xMovement;
    public event Action<bool> OnGroundStateChange;

    private PlayerRenderer _renderer;
    private void Awake()
    {
        _rbcompo = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<PlayerRenderer>();
    }

    public void AddForceToEnitity(Vector2 force, ForceMode2D mode = ForceMode2D.Impulse)
    {
        _rbcompo.AddForce(force, mode);
    }

    public void StopIimmediately(bool isYAxIsTOO = false)
    {
        if (isYAxIsTOO)
            _rbcompo.velocity = Vector2.zero;
        else
            _rbcompo.velocity = new Vector2(0,_rbcompo.velocity.y);
        _xMovement = 0;
    }

    public void SetXMovement(float xMovement)
    {
        _xMovement = xMovement;
    }

    private void GroundChecker()
    {
        bool before = IsGrounded;
        IsGrounded = Physics2D.OverlapBox(
            _groundChecker.position, _checkerSize, 0, _whatIsGround);
        if (before != false)
            OnGroundStateChange?.Invoke(IsGrounded);
    }

    private void MoveCharacter()
    {
       _rbcompo.velocity = new Vector2(_xMovement * _speed,_rbcompo.velocity.y);
        _renderer.FlipController(_xMovement);
    }



    private void FixedUpdate()
    {
        MoveCharacter();
        GroundChecker();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundChecker.position, _checkerSize);
    }

}
