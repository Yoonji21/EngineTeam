using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achromatic : Player
{
    protected override void OnEnable()
    {
        base.OnEnable();
        InputCompo.OnInteractionEvent -= SwithUp;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        InputCompo.OnInteractionEvent += SwithUp;
    }

    public void SwithUp()
    {
        stateMachine.ChangeState("SwithUp");
    }

    protected override void Update()
    {
        base.Update();
        if (IsToadstoolObj())
        {
            InputCompo.OnInteractionEvent += SwithUp;
        }
        else
        {
            InputCompo.OnInteractionEvent -= SwithUp;
        }
    }
}
