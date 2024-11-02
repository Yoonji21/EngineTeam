using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Animation/TypeSO")]
public class AnimationTypeSO : ScriptableObject
{
    public enum PlayerType
    {
        Idle, //가만히있는 애니메이션
        Jump, // 폴짝 뛰는 애니메이션
        Fail, // 뭔가 들고 떨어질수도있어서 그것도 찍어야함 
        Move, // 아기자기하게 걸어다니게하는 모션
        Push, // 물건을 미는모션
        Swith, // 스위치를 내리고 올리는 모션
        Holde // 물건을 아래서 부터 드는 애니메이션
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
