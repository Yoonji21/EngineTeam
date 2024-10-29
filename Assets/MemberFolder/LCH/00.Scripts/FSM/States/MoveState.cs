using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public MoveState(Player agent, StateMachine state, string animBoolName) : base(agent, state, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        float xMove = _player.InputCompo.InputDriection.x;

        _player.MovementCompo.SetXMovement(xMove);

        if (Mathf.Approximately(xMove, 0))
            _player.stateMachine.ChangeState(PlayerType.Idle);
    }
}
