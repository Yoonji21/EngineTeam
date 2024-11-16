using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    [SerializeField] private GameObject _settingUI;

	public void LevelButtonClik()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingBtn()
    {
        _settingUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
