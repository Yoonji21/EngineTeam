using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{

    [SerializeField] private Canvas _stageUI;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ContinuationButtonClik()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void LevelSelectButtonClik()
    {
        _stageUI.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        gameObject.SetActive(false);
    }

    public void MainMenuButtonClik()
    {
        gameObject.SetActive(false);
        _stageUI.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
