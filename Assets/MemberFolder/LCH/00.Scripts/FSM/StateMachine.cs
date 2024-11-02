using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
	public State CurrentState { get; private set; }
    public Dictionary<PlayerType, State> _stateDictionary = new Dictionary<PlayerType, State>();
    private Player player;
    public void Initialized(PlayerType startState, Player _player)
    {
        player = _player;
        CurrentState = _stateDictionary[startState];
        CurrentState.Enter();
    }

    public void ChangeState(PlayerType newState)
    {
        CurrentState.Exit();
        CurrentState = _stateDictionary[newState];
        CurrentState.Enter();
    }

    public void AddState(PlayerType stateEnum, State enemyState) 
    {
        _stateDictionary.Add(stateEnum, enemyState);
    }
}