using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Dictionary<Type, IEntityComponent> _components;

    protected virtual void Awake()
    {
        _components = new Dictionary<Type, IEntityComponent> ();
        GetComponentsInChildren<IEntityComponent>(true).ToList()
            .ForEach(component => _components.Add(component.GetType(), component));

        InitComponents();
        AfterInit();
    }

    private void InitComponents()
    {
        _components.Values.ToList().ForEach(component => component.Initialize(this));
    }

    protected virtual void AfterInit()
    {
        _components.Values.ToList().ForEach(component =>
        {
            if (component is IAfterInitable afterInitable)
            {
                afterInitable.AfterInit();
            }
        });

        _components.Values.Where(compo => compo is IAfterInitable).ToList()
            .ForEach(compo => ((IAfterInitable)compo).AfterInit());
    }

    public T GetCompo<T>(bool isDerived = false) where T : IEntityComponent
    {
        if(_components.TryGetValue(typeof(T), out IEntityComponent component))
        {
            return (T)component;
        }

        if (isDerived != false)
        {
            Type findType = _components.Keys.FirstOrDefault(t => t.IsSubclassOf(typeof(T)));
            if(findType != null)
                return (T)_components[findType];
        }

        return default;
    }
}
