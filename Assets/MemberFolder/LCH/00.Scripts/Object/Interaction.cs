using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour,IEntityComponent
{
    public UnityEvent OnInteractionEvnets;

    private Entity _entity;
    public void Initialize(Entity entity)
    {
        _entity = entity;
    }

    public void InteractionPress()
    {
        InteractionObj();
    }

	private void InteractionObj()
    {
        OnInteractionEvnets?.Invoke();
    }
}
