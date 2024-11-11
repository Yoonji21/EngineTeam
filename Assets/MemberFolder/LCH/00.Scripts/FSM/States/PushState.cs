//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PushState : State
//{
//    public PushState(Player agent, StateMachine state, string animBoolName) : base(agent, state, animBoolName)
//    {
//    }

//    public override void Enter()
//    {
//        base.Enter();
//    }

//    public override void UpdateState()
//    {
//        base.UpdateState();
//        float xMove = _player.InputCompo.InputDriection.x;
//        if (Mathf.Approximately(xMove, 0))
//        {
//            _player.stateMachine.ChangeState(PlayerType.Idle);
//        }
//        else if (!_player.IsPushObj())
//        {
//            _player.stateMachine.ChangeState(PlayerType.Move);
//        }
//    }


//}
