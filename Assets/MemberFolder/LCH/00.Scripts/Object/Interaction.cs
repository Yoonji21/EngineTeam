using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public UnityEvent OnInteractionEvnets;
    public void InteractionPress()
    {
        InteractionObj();
    }

	private void InteractionObj()
    {
        OnInteractionEvnets?.Invoke();
    }
}
