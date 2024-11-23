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
       _dataSO.StageClear += 1;
        DataManger.Intance.SaveData();
        _clearUI.SetActive(false);
        SceneManagers.Inatnce.CurrentSceneLevel++;
        SceneManager.LoadScene(SceneManagers.Inatnce.NextScene());
    }

    public void SelectLevel()
    {
        UIManager.Intance.StageUI.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void SettingBtn()
    {
        _clearUI.SetActive(false);
        _settingUI.SetActive(true);
    }
}

