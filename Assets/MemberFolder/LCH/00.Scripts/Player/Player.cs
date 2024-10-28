using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerState
{
    Idle, //�������ִ� �ִϸ��̼�
    Jump, // ��¦ �ٴ� �ִϸ��̼�
    Fail, // ���� ��� �����������־ �װ͵� ������ 
    Move, // �Ʊ��ڱ��ϰ� �ɾ�ٴϰ��ϴ� ���
    Push, // ������ �̴¸��
    Swith, // ����ġ�� ������ �ø��� ���
    Holde // ������ �Ʒ��� ���� ��� �ִϸ��̼�
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
