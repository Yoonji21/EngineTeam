using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] private Vector2 _objCheckSize;

    public bool IsPushObj()
    {
        bool isPushObj = Physics2D.OverlapBox(transform.position,_objCheckSize ,0,whatIsPushObj);
        return isPushObj;
    }

    public bool IsHoldObj()
    {
        bool isHoldObj = Physics2D.OverlapBox(transform.position, _objCheckSize, 0, whatIsHoldObj);
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _objCheckSize);
    }
}
