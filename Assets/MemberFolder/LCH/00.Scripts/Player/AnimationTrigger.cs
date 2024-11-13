using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour, IEntityComponent
{
    public event Action OnAnimationEnd;
    private Entity _entity;

    public void Initialize(Entity entity)
    {
        _entity = entity;
    }

    protected virtual void AnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }
}
