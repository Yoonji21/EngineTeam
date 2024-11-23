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
        if (_dataSO.StageClear < 9)
        {
            _dataSO.StageClear++;
        }
        DataManger.Intance.SaveData();
        _clearUI.SetActive(false);
        SceneManagers.Inatnce.CurrentSceneLevel++;
        SceneManager.LoadScene(SceneManagers.Inatnce.NextScene());
    }

    public void SelectLevel()
    {
        if(_dataSO.StageClear < 9)
        {
            _dataSO.StageClear++;
        }
        UIManager.Intance.StageUI.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void SettingBtn()
    {
        _clearUI.SetActive(false);
        _settingUI.SetActive(true);
    }
}

