using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : EntityState
{
    private PlayerMovement _mover;
    public JumpState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _mover = entity.GetCompo<PlayerMovement>();
    }

    public override void Enter()
    {
        base.Enter();
        _mover.RbCompo.AddForce(Vector2.up * _player._jumpPower, ForceMode2D.Impulse);
    }

    public override void Update()
    {
        base.Update();
        if (_player.IsPushObj())
            _player.ChangeState("Idle");
        if (_mover.RbCompo.velocity.y < 0)
            _player.ChangeState("Fail");
    }
}
