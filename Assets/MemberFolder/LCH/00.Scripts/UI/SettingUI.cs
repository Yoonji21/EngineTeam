using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{

    [SerializeField] private GameObject _mainUI;
    [SerializeField] private StageDataSO _dataSO;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void BackBtn()
    {
        gameObject.SetActive(false);
        _mainUI.SetActive(true);
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
