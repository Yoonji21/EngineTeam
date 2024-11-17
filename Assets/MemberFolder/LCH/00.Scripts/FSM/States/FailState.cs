using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailState : EntityState
{

    private PlayerMovement _mover;
    public FailState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _mover = entity.GetCompo<PlayerMovement>();

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if (_player.MovementCompo.IsGrounded)
            _player.ChangeState("Idle");
        if (_player.IsPushObj())
            _player.ChangeState("Push");
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
