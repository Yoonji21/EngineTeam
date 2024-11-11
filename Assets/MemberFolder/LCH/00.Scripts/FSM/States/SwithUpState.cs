//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SwithUpState : State
//{
//    public SwithUpState(Player agent, StateMachine state, string animBoolName) : base(agent, state, animBoolName)
//    {
//    }

//    public override void Enter()
//    {
//        _player.MovementCompo.StopIimmediately(true);
//        base.Enter();
//    }

//    public override void UpdateState()
//    {
//        if (!_player.IsToadstoolObj())
//        {
//            float xMove = _player.InputCompo.InputDriection.x;
//            if (Mathf.Abs(xMove) > 0)
//            {
//                _player.stateMachine.ChangeState(PlayerType.Move);
//            }
//            else
//            {
//                _player.stateMachine.ChangeState(PlayerType.Idle);
//            }
//        }
//        base.UpdateState();
//    }
//}
