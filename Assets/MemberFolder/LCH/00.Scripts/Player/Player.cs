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
    SwithUp,
    SwithDown
}
public class Player : Agent
{
    [SerializeField] private LayerMask whatIsPushObj;
    [SerializeField] private LayerMask whatIsToadstoolObj;
    [SerializeField] private Vector2 _objCheckSize;
    public float _jumpPower { get; private set; } = 12f;

    public StateMachine stateMachine;

    public bool IsPushObj()
    {
        bool isPushObj = Physics2D.OverlapBox(transform.position,_objCheckSize ,0,whatIsPushObj);
        return isPushObj;
    }

    public bool IsToadstoolObj()
    {
        bool isToadstoolobj = Physics2D.OverlapBox(transform.position, _objCheckSize, 0, whatIsToadstoolObj);
        return isToadstoolobj;
    }

    protected override void Awake()
    {
        base.Awake();
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

    private void Start()
    {
        stateMachine.Initialized(PlayerType.Idle, this);
        
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _objCheckSize);
       
    }
}
