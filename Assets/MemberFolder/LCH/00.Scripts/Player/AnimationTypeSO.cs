using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Animation/TypeSO")]
public class AnimationTypeSO : ScriptableObject
{
    public enum PlayerType
    {
        Idle, //�������ִ� �ִϸ��̼�
        Jump, // ��¦ �ٴ� �ִϸ��̼�
        Fail, // ���� ��� �����������־ �װ͵� ������ 
        Move, // �Ʊ��ڱ��ϰ� �ɾ�ٴϰ��ϴ� ���
        Push, // ������ �̴¸��
        Swith, // ����ġ�� ������ �ø��� ���
        Holde // ������ �Ʒ��� ���� ��� �ִϸ��̼�
    }

    public string paramName;
    public PlayerType paramType;
    public int hashValue;

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(paramName)) return;
        hashValue = Animator.StringToHash(paramName);
    }
}
