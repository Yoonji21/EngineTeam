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
        _player.MovementCompo.StopIimmediately(false);
        base.Enter();
    }

    public override void UpdateState()
    {
        float xMove = _player.InputCompo.InputDriection.x;
        if (Mathf.Abs(xMove) > 0)
           _player.stateMachine.ChangeState(PlayerType.Move);
        base.UpdateState();
    }
}
