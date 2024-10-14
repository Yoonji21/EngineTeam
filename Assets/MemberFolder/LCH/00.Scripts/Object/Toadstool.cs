using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Toadstool : MonoBehaviour
{
	public UnityEvent OnoffPlayerDictctionEvent;

	public void offPlayerDic()
    {
        OnoffPlayerDictctionEvent?.Invoke();
    }
}
