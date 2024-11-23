using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private StageDataSO _dataSO;
    [SerializeField] private GameObject _settingUI;
    [SerializeField] private GameObject _clearUI;

    private void Awake()
    {
        _clearUI.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void NextSceneBtn()
    {
        _clearUI.SetActive(false);
        if (_dataSO.StageClear < 9)
        {
            _dataSO.StageClear = SceneManagers.Inatnce.CurrentSceneLevel +1;
        }
        DataManger.Intance.SaveData();
        SceneManagers.Inatnce.CurrentSceneLevel++;
        UIManager.Intance.isClearColor = false;
        UIManager.Intance.isClearNoColor = false;
        SceneManager.LoadScene(SceneManagers.Inatnce.NextScene());
    }

    public void SelectLevel()
    {
        if(_dataSO.StageClear < 9)
        {
            _dataSO.StageClear = SceneManagers.Inatnce.CurrentSceneLevel + 1;
        }
        _clearUI.SetActive(false);
        UIManager.Intance.StageUI.SetActive(false);
        UIManager.Intance.isClearColor = false;
        UIManager.Intance.isClearNoColor = false;
        SceneManager.LoadScene(1);
    }

    public void SettingBtn()
    {
        _clearUI.SetActive(false);
        _settingUI.SetActive(true);
    }
}

