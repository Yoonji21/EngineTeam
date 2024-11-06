using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUI : MonoBehaviour
{
    [SerializeField] private Canvas _pauseUI;
	public void ResetButtonClik()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseButtonClik()
    {
        _pauseUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
