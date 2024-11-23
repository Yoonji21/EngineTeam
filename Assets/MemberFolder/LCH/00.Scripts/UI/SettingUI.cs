using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{

    [SerializeField] private GameObject _settingUI;
    [SerializeField] private StageDataSO _dataSO;

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
