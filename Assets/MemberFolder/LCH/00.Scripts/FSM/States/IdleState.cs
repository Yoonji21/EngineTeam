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
        _player.StartCoroutine(SwithingPlayer());

    }

    private IEnumerator SwithingPlayer()
    {
        yield return new WaitForSeconds(1f);
        _player.SwitchingCompo.isSwithing = true;
    }

    public override void Update()
    {
        float xMove = _player.InputCompo.InputDriection.x;
        if (Mathf.Approximately(xMove, 0))
        {
            _mover.RbCompo.velocity = Vector2.zero;
        }

        if (Mathf.Abs(xMove) > 0)
            _player.ChangeState("Move");
        if (_mover.RbCompo.velocity.y < 0)
            _player.ChangeState("Fail");
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
        _player.SwitchingCompo.isSwithing = false;
    }
}
