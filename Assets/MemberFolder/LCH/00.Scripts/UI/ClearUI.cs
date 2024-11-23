using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private StageDataSO _dataSO;
    [SerializeField] private GameObject _settingUI;
    [SerializeField] private TextMeshProUGUI _stageText;

    private void Awake()
    {
        gameObject.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        _stageText.text = $"Stage {SceneManagers.Inatnce.CurrentSceneLevel} Clear";
    }

    public void NextSceneBtn()
    {
       _dataSO.StageClear += 1;
        DataManger.Intance.SaveData();
        SceneManagers.Inatnce.CurrentSceneLevel++;
        SceneManager.LoadScene(SceneManagers.Inatnce.NextScene());
        gameObject.SetActive(false);
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingBtn()
    {
        _settingUI.SetActive(true);
        gameObject.SetActive(false);
    }
}

