using UnityEngine;

[CreateAssetMenu(menuName = "SO/StateSo")]
public class StateSO : ScriptableObject
{
    public string stateName;
    public string className;
    public AnimParamSO stateAnim;
}
