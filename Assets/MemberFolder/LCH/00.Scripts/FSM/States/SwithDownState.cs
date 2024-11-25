using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithDownState : EntityState
{
    private Interaction _interaction;
    public SwithDownState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
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
        if (!_player.isSwithOn || _isTriggerCall)
        {
            if (_player.isChromatilColorArtifact)
            {
                _player.Artifact.SetActive(true);
                _player.isChromatilColorArtifact = false;
            }
            _player.ChangeState("Idle");
        }
        base.Update();
    }
}
