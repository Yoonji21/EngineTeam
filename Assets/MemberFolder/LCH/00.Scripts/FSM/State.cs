using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
	protected Agent owner;
	protected StateMachine StateMachine;
	protected AnimationTypeSO _animParam;
	protected bool _endTriggerCalled;

	public State(Agent agent,AnimationTypeSO animationType)
    {
		owner = agent;
		_animParam = animationType;
	}

	public virtual void Enter()
    {
		owner.RendererCompo.SetParam(_animParam, true);
		_endTriggerCalled = false;
    }

	public virtual void UpdateState()
    {

    }

	public virtual void Exit()
    {
		owner.RendererCompo.SetParam(_animParam, false);
	}

	public void AnimationEndTrigger()
	{
		_endTriggerCalled = true;
	}

}
