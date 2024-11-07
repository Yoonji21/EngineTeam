using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
	protected Player _player;
	protected StateMachine StateMachine;
	protected bool _endTriggerCalled;
	protected int _animBoolHash;

	public State(Player agent,StateMachine state, string animBoolName)
	{
		_player = agent;
		StateMachine = state;
		_animBoolHash = Animator.StringToHash(animBoolName);
	}

	public virtual void Enter()
    {

		_player.InputCompo.OnJumpEvent += HandleJumpPressed;
		_player.AnimatorCompo.SetBool(_animBoolHash, true);
		_endTriggerCalled = false;
    }

	public virtual void UpdateState()
    {

    }

	protected virtual void HandleJumpPressed()
	{

	}

	public virtual void Exit()
    {
		_player.InputCompo.OnJumpEvent -= HandleJumpPressed;
		_player.AnimatorCompo.SetBool(_animBoolHash, false);
	}

	public void AnimationEndTrigger()
	{
		_endTriggerCalled = true;
	}

}
