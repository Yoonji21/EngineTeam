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
public abstract class Player : Entity
{

    [Header("FSM")]
    [SerializeField] private EntityStatesSO _playerFSM;

    [field: SerializeField] public InputSystem InputCompo { get; private set; }
    public PlayerMovement MovementCompo { get; private set; }
    public SwitchingPlayer SwitchingCompo { get; private set; }

    public Interaction IntaractionCompo { get; private set; }

    [SerializeField] private LayerMask whatIsPushObj;
    [SerializeField] private LayerMask whatIsToadstoolObj;
    [SerializeField] private Vector2 _objCheckSize;
    [SerializeField] private Transform _checkTrm;
    [field : SerializeField] public float _jumpPower { get;  set; } = 12f;

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
        IntaractionCompo = GetCompo<Interaction>();
       
    }

    protected virtual void OnEnable()
    {
        stateMachine.Initialize("Idle");
        InputCompo.OnJumpEvent += HandheldJump;
        GetCompo<AnimationTrigger>().OnAnimationEnd += HandleAnimationEnd;
        InputCompo.OnswithingPlayerEvent += SwitchingCompo.SwitchingPlayerUI;
        
    }

    private void HandheldJump()
    {
        if (MovementCompo.IsGrounded)
        {
            stateMachine.ChangeState("Jump");
        }
    }

    public void SwithUp()
    {
        stateMachine.ChangeState("SwithUp");
    }

    protected virtual void OnDisable()
    {
        InputCompo.OnswithingPlayerEvent -= SwitchingCompo.SwitchingPlayerUI;
        InputCompo.OnInteractionEvent -= SwithUp;
        GetCompo<AnimationTrigger>().OnAnimationEnd -= HandleAnimationEnd;
    }

    private void HandleAnimationEnd()
    {
        CurrentState.AnimationEndTrigger();
    }

   protected virtual void Update()
    {
        stateMachine.currentState.Update();
        if (IsToadstoolObj())
        {
            InputCompo.OnInteractionEvent += SwithUp;
        }
        else
        {
            InputCompo.OnInteractionEvent -= SwithUp;
        }
    }

    public EntityState GetState(string state) => stateMachine.GetState(state);

    public void ChangeState(string newState) => stateMachine.ChangeState(newState);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_checkTrm.position, _objCheckSize);
       
    }
}
