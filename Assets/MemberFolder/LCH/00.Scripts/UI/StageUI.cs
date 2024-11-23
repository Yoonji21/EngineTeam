using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;

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
        gameObject.SetActive(false);
        _pauseUI.SetActive(true);
        Time.timeScale = 0;
    }
}
