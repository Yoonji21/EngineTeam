using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : EntityState
{
    private PlayerMovement _mover;
    public MoveState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _mover = entity.GetCompo<PlayerMovement>();
    }

    public override void Enter()
    {
        base.Enter();
        _mover.StopIimmediately(false);
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
