using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ContinuationButtonClik()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void LevelSelectButtonClik()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void MainMenuButtonClik()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
