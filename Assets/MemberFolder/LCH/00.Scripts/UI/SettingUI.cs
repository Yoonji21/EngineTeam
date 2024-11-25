using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SettingUI : MonoBehaviour
{

    [SerializeField] private GameObject _settingUI;
    [SerializeField] private StageDataSO _dataSO;

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            _settingUI.SetActive(true);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void BackBtn()
    {

        _settingUI.SetActive(false);
    }

    public void GameReSet()
    {
        _dataSO.StageClear = 0;
    }

    public void LevelAllUnLock()
    {
        _dataSO.StageClear = 9;
    }

    public void ExitGame()
    {
        DataManger.Intance.SaveData();
        Application.Quit();
    }
}
