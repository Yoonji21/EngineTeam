using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushState : EntityState
{
    private PlayerMovement _mover;
    public PushState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _mover = entity.GetCompo<PlayerMovement>();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        float xMove = _player.InputCompo.InputDriection.x;
        if (Mathf.Approximately(xMove, 0))
        {
            _player.ChangeState("Idle");
        }
        else if (!_player.IsPushObj())
        {
            _player.ChangeState("Move");
        }
    }


}
