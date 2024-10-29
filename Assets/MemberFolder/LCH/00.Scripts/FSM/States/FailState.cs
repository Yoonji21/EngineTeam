using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailState : State
{
    public FailState(Player agent, StateMachine state, string animBoolName) : base(agent, state, animBoolName)
    {
    }
}
