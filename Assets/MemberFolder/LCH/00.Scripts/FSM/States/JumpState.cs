using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public JumpState(Player agent, StateMachine state, string animBoolName) : base(agent, state, animBoolName)
    {
    }
}
