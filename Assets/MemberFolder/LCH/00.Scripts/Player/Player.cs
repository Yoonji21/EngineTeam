using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum PlayerType
{
    Idle, 
    Jump, 
    Fail, 
    Move, 
    Push, 
    SwithUp
}
public class Player : Entity
{

    [Header("FSM")]
    [SerializeField] private EntityStatesSO _playerFSM;

    [field: SerializeField] public InputSystem InputCompo { get; private set; }
    public PlayerMovement MovementCompo { get; private set; }

    public Rigidbody2D RbCompo { get; private set; }
    public SwitchingPlayer SwitchingCompo { get; private set; }

    public Interaction IntaractionCompo { get; private set; }

    [SerializeField] private LayerMask whatIsPushObj;
    [SerializeField] private LayerMask whatIsToadstoolObj;
    [SerializeField] private Vector2 _objCheckSize;
    [SerializeField] private Transform _checkTrm;
    public float _jumpPower { get; private set; } = 5f;

    public bool isSwithOn { get; set; } = false;

    [SerializeField] public StateMachine stateMachine;
    public EntityState CurrentState => stateMachine.currentState;

    public bool IsPushObj()
    {
        bool isPushObj = Physics2D.OverlapBox(_checkTrm.position,_objCheckSize ,0,whatIsPushObj);
        return isPushObj;
    }

    public bool IsToadstoolObj()
    {
        bool isToadstoolobj = Physics2D.OverlapBox(_checkTrm.position, _objCheckSize, 0, whatIsToadstoolObj);
        return isToadstoolobj;
    }

    protected override void AfterInit()
    {
        base.AfterInit();
        stateMachine = new StateMachine(_playerFSM, this);
        MovementCompo = GetCompo<PlayerMovement>();
        SwitchingCompo = GetCompo<SwitchingPlayer>();
        InputCompo.OnswithingPlayerEvent += SwitchingCompo.SwitchingPlayerUI;
    }

    private void OnDestroy()
    {
        InputCompo.OnswithingPlayerEvent -= SwitchingCompo.SwitchingPlayerUI;
    }

     private void HandleAnimationEnd()
    {
        CurrentState.AnimationEndTrigger();
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_checkTrm.position, _objCheckSize);
       
    }
}
