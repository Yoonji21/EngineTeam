using UnityEngine;

public abstract class EntityState
{
    protected Entity _entity;
    protected Player _player;
    protected AnimParamSO _animParam;
    protected bool _isTriggerCall;

    protected PlayerRenderer _renderer;

    public EntityState(Entity entity, AnimParamSO animParam)
    {
        _entity = entity;
        _player = entity as Player;
        _animParam = animParam;
        _renderer = _entity.GetCompo<PlayerRenderer>();
    }

    public virtual void Enter()
    {
        _renderer.SetParam(_animParam, true);
        _isTriggerCall = false;
    }

    public virtual void Update() { }

    public virtual void Exit()
    {
        _renderer.SetParam(_animParam, false);
    }

    public virtual void AnimationEndTrigger()
    {
        _isTriggerCall = true;
    }
}
