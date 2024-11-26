using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUI : MonoBehaviour
{
    [SerializeField] private GameObject _stageUI;
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private GameObject _InGameTip;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ResetButtonClik()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseButtonClik()
    {
        _stageUI.SetActive(false);
        _pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void InGameBtnClik()
    {
        _InGameTip.SetActive(true);
        Time.timeScale = 0;
    }
}
