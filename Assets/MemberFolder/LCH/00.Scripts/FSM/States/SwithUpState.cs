using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithUpState : State
{
    public SwithUpState(Player agent, StateMachine state, string animBoolName) : base(agent, state, animBoolName)
    {
    }

    public override void Enter()
    {
        _player.MovementCompo.StopIimmediately(false);
        base.Enter();
    }

    public override void UpdateState()
    {
        if (_endTriggerCalled)
        {
            _player.stateMachine.ChangeState(PlayerType.Idle);
        }
        base.UpdateState();
    }
}
