using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	public State CurrentState { get; private set; }
	public Dictionary<PlayerState, State> StateDictionary = new Dictionary<PlayerState, State>();
	public Agent _player;

    public void Initialized(PlayerState Startstate, Agent player)
    {
        _player = player;
        CurrentState = StateDictionary[Startstate];

        //CurrentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        //CurrentState.Exit();
        CurrentState = StateDictionary[newState];
        //CurrentState.Enter();
    }

    public void AddState(PlayerState playerEnum, State playerState)
    {
        StateDictionary.Add(playerEnum, playerState);
    }
}