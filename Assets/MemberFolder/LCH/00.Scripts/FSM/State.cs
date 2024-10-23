using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
	protected Agent owner;
	protected StateMachine StateMachine;
	protected int _animBoolHash; 
	protected bool _endTriggerCalled;

	public State(Agent agent,StateMachine stateMachine, string animBoolName)
    {
		owner = agent;
		StateMachine = stateMachine;
    }

	public virtual void Enter()
    {
		_endTriggerCalled = false;
    }

	public virtual void UpdateState()
    {

    }

	public virtual void Exit()
    {
		
    }

	public void AnimationEndTrigger()
	{
		_endTriggerCalled = true;
	}

}
