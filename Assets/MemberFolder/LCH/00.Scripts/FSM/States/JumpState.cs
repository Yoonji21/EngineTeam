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
        _mover.StopIimmediately(true);
        _mover.AddForceToEntity(new Vector2(0, _player._jumpPower));
    }

    public override void Update()
    {
        float xMove = _player.InputCompo.InputDriection.x;
        if (Mathf.Abs(xMove) > 0)
            _player.ChangeState("Move");
        if (_player.IsPushObj())
            _player.ChangeState("Idle");
        if (_mover.RbCompo.velocity.y < 0)
            _player.ChangeState("Fail");
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
        _player._jumpPower = 8f;
    }
}
