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
    [SerializeField] private LayerMask whatIsPushOrHoldObj;
    [SerializeField] private float _rayDirction;

    public bool IsPushOrHoldObj()
    {
        bool isPushOrHoldObj = Physics2D.Raycast(transform.position, Vector2.right, _rayDirction, whatIsPushOrHoldObj);
        return isPushOrHoldObj;
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
        IsPushOrHoldObj();
    }
}
