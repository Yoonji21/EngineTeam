//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FailState : State
//{
//    public FailState(Player agent, StateMachine state, string animBoolName) : base(agent, state, animBoolName)
//    {
//    }

//    public override void Enter()
//    {
//        base.Enter();
//    }

//    public override void UpdateState()
//    {
//        if (_player.MovementCompo.IsGrounded)
//            _player.stateMachine.ChangeState(PlayerType.Idle);
//        if (_player.IsPushObj())
//            _player.stateMachine.ChangeState(PlayerType.Push);
//        base.UpdateState();
//    }
//}
