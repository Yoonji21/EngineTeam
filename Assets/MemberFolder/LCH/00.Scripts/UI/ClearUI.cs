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
    [SerializeField] private TextMeshProUGUI _stageText;

    private void Awake()
    {
        _clearUI.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        UIManager.Intance.StageUI.SetActive(false);
        _stageText.text = $"Stage {SceneManagers.Inatnce.CurrentSceneLevel} Clear";
    }

    public void NextSceneBtn()
    {
       _dataSO.StageClear += 1;
        DataManger.Intance.SaveData();
        SceneManagers.Inatnce.CurrentSceneLevel++;
        SceneManager.LoadScene(SceneManagers.Inatnce.NextScene());
        _clearUI.SetActive(false);
    }

    public void SelectLevel()
    {
        UIManager.Intance.StageUI.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void SettingBtn()
    {
        _settingUI.SetActive(true);
        _clearUI.SetActive(false);
    }
}

