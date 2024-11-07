using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Player agent, StateMachine state, string animBoolName) : base(agent, state, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.RbCompo.velocity = Vector2.zero;
    }

    public override void UpdateState()
    {
        float xMove = _player.InputCompo.InputDriection.x;

       if(Mathf.Approximately(xMove, 0))
        {
            _player.RbCompo.velocity = Vector2.zero;
        }

        if (Mathf.Abs(xMove) > 0)
           _player.stateMachine.ChangeState(PlayerType.Move);
        if (_player.IsToadstoolObj())
            _player.StartCoroutine(SwithOnOffCoroutine(1.6f));
        if (!_player.IsToadstoolObj())
            _player.StopAllCoroutines();
        base.UpdateState();
    }

    private IEnumerator SwithOnOffCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        _player.stateMachine.ChangeState(PlayerType.SwithUp);
    }

    protected override void HandleJumpPressed()
    {
        if (_player.MovementCompo.IsGrounded)
            _player.stateMachine.ChangeState(PlayerType.Jump);
    }
}
