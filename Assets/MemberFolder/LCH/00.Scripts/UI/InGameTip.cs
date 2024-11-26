using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InGameTip : MonoBehaviour
{
    [SerializeField] private GameObject _inGameView;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void XBtnClick()
    {
        _inGameView.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            _inGameView.SetActive(false);
        }
    }
}
