using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Jump,
    Fail,
    Move,
    Push,
    Swith,
    Holde
}

public class Player : Agent
{
    [SerializeField] private LayerMask whatIsPushObj;
    [SerializeField] private LayerMask whatIsHoldObj;
    [SerializeField] private float _rayDirction;

    public bool IsPushObj()
    {
        bool isPushObj = Physics2D.Raycast(transform.position, Vector2.right, _rayDirction, whatIsPushObj);
        return isPushObj;
    }

    public bool IsHoldObj()
    {
        bool isHoldObj = Physics2D.Raycast(transform.position, Vector2.right, _rayDirction, whatIsHoldObj);
        return isHoldObj;
    }

    //public StateMachine stateMachine;
    //protected override void Awake()
    //{
    //    base.Awake();
    //    stateMachine = new StateMachine();
    //    stateMachine.Initialized(PlayerState.Idle, this);
    //}

    private void Update()
    {
        //stateMachine.CurrentState.UpdateState();
        IsPushObj();
        IsHoldObj();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position,Vector3.right * _rayDirction);
    }
}
