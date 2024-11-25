using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{

    [SerializeField] private GameObject _stageUI;
    [SerializeField] private GameObject _pauseUI;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ContinuationButtonClik()
    {
       _pauseUI.SetActive(false);
        _stageUI.SetActive(true);
        Time.timeScale = 1;
    }

    public void LevelSelectButtonClik()
    {
        _stageUI.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        _pauseUI.SetActive(false);
    }

    public void MainMenuButtonClik()
    {
       _pauseUI.SetActive(false);
        _stageUI.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
