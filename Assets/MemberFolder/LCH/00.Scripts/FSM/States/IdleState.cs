using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EntityState
{
    private PlayerMovement _mover;
    public IdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _mover = entity.GetCompo<PlayerMovement>();
    }

    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.StopIimmediately(true);

    }

    public override void Update()
    {
        float xMove = _player.InputCompo.InputDriection.x;
        if (_mover.RbCompo.velocity.y < 0)
            _player.ChangeState("Fail");

        if (Mathf.Abs(xMove) > 0)
            _player.ChangeState("Move");
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
