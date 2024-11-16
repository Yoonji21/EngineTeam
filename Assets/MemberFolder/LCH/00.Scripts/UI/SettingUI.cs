using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{

    [SerializeField] private GameObject _mainUI;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void BackBtn()
    {
        gameObject.SetActive(false);
        _mainUI.SetActive(true);
    }
}
