//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class JumpState : State
//{
//    public JumpState(Player agent, StateMachine state, string animBoolName) : base(agent, state, animBoolName)
//    {
//    }

//    public override void Enter()
//    {
//        base.Enter();
//        _player.RbCompo.AddForce(Vector2.up * _player._jumpPower, ForceMode2D.Impulse);
//    }

//    public override void UpdateState()
//    {
//        base.UpdateState();
//        if (_player.IsPushObj())
//            _player.stateMachine.ChangeState(PlayerType.Idle);
//        if (_player.RbCompo.velocity.y < 0)
//            _player.stateMachine.ChangeState(PlayerType.Fail);
//    }
//}
