using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public UnityEvent OnoffPlayerDictctionEvent;
    public void InteractionPress()
    {
        offPlayerDic();
    }

	private void offPlayerDic()
    {
        OnoffPlayerDictctionEvent?.Invoke();
    }
}