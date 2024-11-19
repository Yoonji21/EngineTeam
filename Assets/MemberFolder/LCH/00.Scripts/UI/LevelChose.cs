using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelChose : MonoBehaviour
{

    [SerializeField] private Button[] _LevelBtn;
    [SerializeField] private StageDataSO _stageData;

    private void Awake()
    {
        for(int i = _stageData.StageClear+1; i<_LevelBtn.Length; i++)
        {
            _LevelBtn[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        for(int i = 0; i < _stageData.StageClear; i++)
        {
            _LevelBtn[i].gameObject.SetActive(true);
        }
    }

    public void StageSecne(int sceneCount)
    {
        SceneManagers.Inatnce.CurrentSceneLevel = sceneCount -1;
        SceneManagers.Inatnce.CurrentSceneNum = sceneCount;
        SceneManager.LoadScene(sceneCount);
    }

    public void BackButtonClik()
    {
        SceneManager.LoadScene(0);
    }
}
