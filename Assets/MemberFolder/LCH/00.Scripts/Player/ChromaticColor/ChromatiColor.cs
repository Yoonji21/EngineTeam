using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromatiColor : Player
{
    private GameObject[] _invisibleObjs;
    [field:SerializeField] public GameObject Artifact;

    protected override void AfterInit()
    {
        base.AfterInit();
        _invisibleObjs = GameObject.FindGameObjectsWithTag("InvisibleObj");
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override  void OnEnable()
    {

        if (_invisibleObjs == null)
        {
            return;
        }

        for (int i = 0; i < _invisibleObjs.Length; i++)
            _invisibleObjs[i].SetActive(false);
    }

    protected override void OnDisable()
    {
        if(_invisibleObjs == null)
        {
            return;
        }

        for (int i = 0; i < _invisibleObjs.Length; i++)
            _invisibleObjs[i].SetActive(true);
    }
}
