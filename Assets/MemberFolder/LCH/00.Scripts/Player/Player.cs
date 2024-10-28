using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerState
{
    Idle, //가만히있는 애니메이션
    Jump, // 폴짝 뛰는 애니메이션
    Fail, // 뭔가 들고 떨어질수도있어서 그것도 찍어야함 
    Move, // 아기자기하게 걸어다니게하는 모션
    Push, // 물건을 미는모션
    Swith, // 스위치를 내리고 올리는 모션
    Holde // 물건을 아래서 부터 드는 애니메이션
}

public class Player : Agent
{
    [SerializeField] private LayerMask whatIsPushObj;
    [SerializeField] private Vector2 _objCheckSize;

    public bool IsPushObj()
    {
        bool isPushObj = Physics2D.OverlapBox(transform.position,_objCheckSize ,0,whatIsPushObj);
        return isPushObj;
    }

    //public StateMachine stateMachine;
    //protected override void Awake()
    //{
    //    base.Awake();
    //    stateMachine = new StateMachine();
    //    stateMachine.Initialized(PlayerState.Idle, this);
    //}

    private void Update()
    {
        //stateMachine.CurrentState.UpdateState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _objCheckSize);
    }
}
