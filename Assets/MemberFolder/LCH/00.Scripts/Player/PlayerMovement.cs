using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour,IEntityComponent
{
    [field:SerializeField] public float _speed;
    public Rigidbody2D RbCompo { get; private set; }
    public Vector3 _xMove;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Vector2 _checkerSize;

    private Entity _entity;
    public bool IsGrounded { get; private set; }
    private float _xMovement;

    private PlayerRenderer _renderer;
    public void StopIimmediately(bool isYAxIsTOO = false)
    {
        if (isYAxIsTOO)
            RbCompo.velocity = Vector2.zero;
        else
            RbCompo.velocity = new Vector2(0, RbCompo.velocity.y);
        _xMovement = 0;
    }

    public void AddForceToEntity(Vector2 force, ForceMode2D mode = ForceMode2D.Impulse)
    {
       RbCompo.AddForce(force, mode);
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
    }


    private void MoveCharacter()
    {
        RbCompo.velocity = new Vector2(_xMovement * _speed, RbCompo.velocity.y);
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

    public void Initialize(Entity entity)
    {
        _entity = entity;
        _renderer = GetComponentInChildren<PlayerRenderer>();
        RbCompo = GetComponent<Rigidbody2D>();
    }
}
