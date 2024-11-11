//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IdleState : EntityState
//{
//    private Player _player;
//    public IdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
//    {
//        _player = entity as Player;
//    }

//    public override void Enter()
//    {
//        base.Enter();
//        _player.MovementCompo.StopIimmediately(true);
//    }

//    public override void Update()
//    {
//        float xMove = _player.InputCompo.InputDriection.x;
//       if(Mathf.Approximately(xMove, 0))
//        {
//            _player.RbCompo.velocity = Vector2.zero;
//        }

//        if (Mathf.Abs(xMove) > 0)
//           _player.stateMachine.ChangeState(PlayerType.Move);
//        if (_player.IsToadstoolObj())
//            _player.StartCoroutine(SwithOnOffCoroutine(1.6f));
//        else
//            _player.StopAllCoroutines();
//        if (_player.RbCompo.velocity.y < 0)
//            _player.stateMachine.ChangeState(PlayerType.Fail);
//        base.Update();
//    }

//    private IEnumerator SwithOnOffCoroutine(float time)
//    {
//        yield return new WaitForSeconds(time);
//        _player.stateMachine.ChangeState(PlayerType.SwithUp);
//    }
//}
