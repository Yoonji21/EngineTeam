using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromatiColor : MonoBehaviour
{

    private GameObject[] _invisibleObjs;

    private void Awake()
    {
        _invisibleObjs = GameObject.FindGameObjectsWithTag("InvisibleObj");

    }

    private void OnEnable()
    {
     
        for (int i = 0; i < _invisibleObjs.Length; i++)
            _invisibleObjs[i].SetActive(false);
    }

    private void OnDisable()
    {
        for (int i = 0; i < _invisibleObjs.Length; i++)
            _invisibleObjs[i].SetActive(true);
    }
}
