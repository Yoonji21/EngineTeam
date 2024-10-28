using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StateSO", menuName = "SO/FSM/State")]
public class StateTypeSO : MonoBehaviour
{
    public string stateName;
    public string className;
    public AnimationTypeSO stateAnim;
}
