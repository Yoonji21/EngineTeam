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
    public StateMachine stateMachine;
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new StateMachine();
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();
    }
}
