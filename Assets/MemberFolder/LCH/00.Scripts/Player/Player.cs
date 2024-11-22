using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;


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

    [field: SerializeField] public InputSystem InputCompo { get; set; }
    [field : SerializeField]public PlayerMovement MovementCompo { get; protected set; }

    [field: SerializeField] public Interaction IntaractionCompo { get; protected set; }

    [field : SerializeField] public AchromaticType AchromaticTypes { get; protected set; }
    [field: SerializeField] public ChromatiType ChromatiTypes { get; protected set; }

    public GameObject Artifact;

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
        stateMachine.Initialize("Idle");
        IntaractionCompo.GetComponent<Interaction>();
    }

    protected void HandheldJump()
    {
        if (MovementCompo.IsGrounded)
        {
            stateMachine.ChangeState("Jump");
        }
    }


    protected void HandleAnimationEnd()
    {
        CurrentState.AnimationEndTrigger();
    }

   protected virtual void Update()
    {
        stateMachine.currentState.Update();
    }

    public EntityState GetState(string state) => stateMachine.GetState(state);

    public void ChangeState(string newState) => stateMachine.ChangeState(newState);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_checkTrm.position, _objCheckSize);
       
    }
}


[Serializable]
public struct AchromaticType
{
    public GameObject SwithingUI;
    public Player SwithingPlayer;
    public SpriteRenderer PlayerVisual;
    public GameObject MyBackGround;
    public Rigidbody2D MyRigidbody;
    public CinemachineVirtualCamera Vcame;
    public BoxCollider2D MyBoxCollider;
    public GameObject MyArtifact;
}

[Serializable]
public struct ChromatiType
{
    public GameObject SwithingUI;
    public Player SwithingPlayer;
    public SpriteRenderer PlayerVisual;
    public GameObject MyBackGround;
    public Rigidbody2D MyRigidbody;
    public CinemachineVirtualCamera Vcame;
    public BoxCollider2D MyBoxCollider;
    public GameObject MyArtifact;
}
