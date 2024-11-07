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
public class Player : Agent
{
    [SerializeField] private LayerMask whatIsPushObj;
    [SerializeField] private LayerMask whatIsToadstoolObj;
    [SerializeField] private Vector2 _objCheckSize;
    [SerializeField] private Transform _checkTrm;
    public float _jumpPower { get; private set; } = 5f;

    public bool isSwithOn { get; set; } = false;

    [SerializeField] public StateMachine stateMachine;

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

    private void AddState()
    {
        stateMachine = new StateMachine();

        foreach (PlayerType stateEnum in Enum.GetValues(typeof(PlayerType)))
        {
            try
            {
                string enumName = stateEnum.ToString();
                Type t = Type.GetType(enumName + "State");
                State state = Activator.CreateInstance(t, this, stateMachine, enumName) as State;

                stateMachine._stateDictionary.Add(stateEnum, state);

            }
            catch (Exception ex)
            {
                Debug.LogError($"<color=red>{stateEnum.ToString()}</color> loading error, Message : {ex.Message}");
            }
        }
    }
    [SerializeField] string currentState = null;
    private void Update()
    {
        //Debug.Log(stateMachine.CurrentState);
        currentState = stateMachine.CurrentState.ToString();
        stateMachine.CurrentState.UpdateState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_checkTrm.position, _objCheckSize);
       
    }

    public override void AnimationEndTrigger()
    {
        stateMachine.CurrentState.AnimationEndTrigger();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        AddState();
        stateMachine.Initialized(PlayerType.Idle, this);
        stateMachine.CurrentState.Enter();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        stateMachine.CurrentState.Exit();
    }
}
