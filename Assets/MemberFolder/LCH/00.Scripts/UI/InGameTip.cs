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
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Time.timeScale = 1;
            _inGameView.SetActive(false);
        }
    }
}
