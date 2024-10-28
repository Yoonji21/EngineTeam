using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    public float FacingDirection { get; private set; } = 1; //오른쪽이 1, 왼쪽이 -1

    private Player _player;

    private Animator _animator;

    public void Initialize(Player player)
    {
        _player = player;
        _animator = GetComponent<Animator>();
    }

    public void SetParam(AnimationTypeSO parm, bool value)
       => _animator.SetBool(parm.hashValue, value);
    public void SetParam(AnimationTypeSO parm, float value)
        => _animator.SetFloat(parm.hashValue, value);
    public void SetParam(AnimationTypeSO parm, int value)
        => _animator.SetInteger(parm.hashValue, value);
    public void SetParam(AnimationTypeSO parm)
        => _animator.SetTrigger(parm.hashValue);

    #region Flip Controller
    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0, 180f, 0);
    }

    public void FlipController(float xMove)
    {
        if (Mathf.Abs(FacingDirection + xMove) < 0.5f)
            Flip();
    }

    #endregion
}
