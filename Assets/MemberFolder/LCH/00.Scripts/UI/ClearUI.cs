using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private StageDataSO _dataSO;
    [SerializeField] private GameObject _settingUI;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void NextSceneBtn()
    {
        SceneManager.LoadScene(SceneManagers.Inatnce.NextScene());
        if (_dataSO.StageClear >= 9)
            return;
       _dataSO.StageClear += 1;
        DataManger.Intance.SaveData();
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

