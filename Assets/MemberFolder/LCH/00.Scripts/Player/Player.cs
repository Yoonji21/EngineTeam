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
    Swith 
}
public class Player : Agent
{
    [SerializeField] private LayerMask whatIsPushObj;
    [SerializeField] private Vector2 _objCheckSize;

    [SerializeField] private float _jumpPower = 12f;
    [SerializeField] private int _jumpCount = 2;

    private int _currentJumpCount = 0;

    public StateMachine stateMachine;

    public bool IsPushObj()
    {
        bool isPushObj = Physics2D.OverlapBox(transform.position,_objCheckSize ,0,whatIsPushObj);
        return isPushObj;
    }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine();
        MovementCompo.OnGroundStateChange += HandleGroundStateChange;

        //foreach (PlayerType stateEnum in Enum.GetValues(typeof(PlayerType)))
        //{
        //    try
        //    {
        //        string enumName = stateEnum.ToString();
        //        Type t = Type.GetType(enumName + "State");
        //        State state = Activator.CreateInstance(t, this) as State;
        //        _stateMachine._stateDictionary.Add(stateEnum, state);

        //    }
        //    catch(Exception ex)
        //    {
        //        Debug.LogError($"<color=red>{stateEnum.ToString()}</color> loading error, Message : {ex.Message}");
        //    }
        //}

        stateMachine.AddState(PlayerType.Idle, new IdleState(this, stateMachine , "Idle"));
        stateMachine.AddState(PlayerType.Move, new MoveState(this, stateMachine, "Move"));

    }

    private void Start()
    {
        stateMachine.Initialized(PlayerType.Idle, this);
        
    }
    private void HandleGroundStateChange(bool isGrounded)
    {
        if (isGrounded)
            _currentJumpCount = _jumpCount;
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();
    }

    private void OnDestroy()
    {
        MovementCompo.OnGroundStateChange -= HandleGroundStateChange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _objCheckSize);
       
    }
}
