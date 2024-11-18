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
        if (_isTriggerCall)
        {
            Debug.Log("³¡³µ´Ù");
            float xMove = _player.InputCompo.InputDriection.x;
            if (Mathf.Abs(xMove) > 0)
            {
                _player.ChangeState("Move");
            }
            else
            {
                _player.stateMachine.ChangeState("Idle");
            }
        }
        base.Update();
    }
}
