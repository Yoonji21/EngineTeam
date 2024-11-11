using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStatesSO", menuName = "SO/FSM/EntityStatesSO")]
public class EntityStatesSO : ScriptableObject
{
    public List<StateSO> states;
    
    private Dictionary<string, StateSO> _statesDictionary;

    public StateSO this[string stateName] => 
        _statesDictionary.GetValueOrDefault(stateName);

    private void OnEnable()
    {
        if (states == null) return;

        _statesDictionary = new Dictionary<string, StateSO>();
        foreach (StateSO state in states)
            _statesDictionary.Add(state.stateName, state);
    }
}
