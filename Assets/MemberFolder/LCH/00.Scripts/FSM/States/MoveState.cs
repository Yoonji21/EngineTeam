using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : EntityState
{
    public MoveState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
    }

    public override void Update()
    {
        base.Update();
        float xMove = _player.InputCompo.InputDriection.x;
        _player.MovementCompo.SetXMovement(xMove);

        if (Mathf.Approximately(xMove, 0))
            _player.ChangeState("Idle");

        if (_player.IsPushObj())
            _player.ChangeState("Push");
    }
}
