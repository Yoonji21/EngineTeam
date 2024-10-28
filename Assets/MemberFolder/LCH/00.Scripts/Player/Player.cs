using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Agent
{
    [Header("FSM")]

    [SerializeField] private List<StateTypeSO> _statList;

    [SerializeField] private LayerMask whatIsPushObj;
    [SerializeField] private Vector2 _objCheckSize;

    [SerializeField] private float _jumpPower = 12f;
    [SerializeField] private int _jumpCount = 2;

    private int _currentJumpCount = 0;
    private PlayerMovement _mover;

    private StateMachine _stateMachine;
    private Dictionary<StateTypeSO, State> _stateDictionary;

    public bool IsPushObj()
    {
        bool isPushObj = Physics2D.OverlapBox(transform.position,_objCheckSize ,0,whatIsPushObj);
        return isPushObj;
    }

    public StateMachine stateMachine;
    protected override void Awake()
    {
        base.Awake();
        _stateMachine = new StateMachine();
        _stateDictionary = new Dictionary<StateTypeSO, State>();

        foreach (StateTypeSO state in _statList)
        {
            try
            {
                Type type = Type.GetType(state.className);
                var playerState = Activator.CreateInstance(type, this, state.stateAnim) as State;
                _stateDictionary.Add(state, playerState);
            }
            catch (Exception ex)
            {
                Debug.LogError($"<color=red>{state.className}</color> loading error, Message : {ex.Message}");
            }
        }
    }

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
