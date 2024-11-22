using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithUpState : EntityState
{

    private Interaction _interaction;
    public SwithUpState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _interaction = entity.GetCompo<Interaction>();
    }

    public override void Enter()
    {
        _player.MovementCompo.StopIimmediately(true);
        _interaction.InteractionPress();

        base.Enter();
    }

    public override void Update()
    {

        if (!_player.IsToadstoolObj())
        {
            _player.Artifact.SetActive(true);
            _player.ChangeState("Idle");
        }
        base.Update();
    }
}
