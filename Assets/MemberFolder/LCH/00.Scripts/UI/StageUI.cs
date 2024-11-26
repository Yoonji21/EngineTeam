using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StageUI : MonoBehaviour
{
    [SerializeField] private GameObject _stageUI;
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private GameObject _InGameTip;

    private RectTransform rectTransform;


    private void Awake()
    {
        rectTransform = _pauseUI.GetComponent<RectTransform>();
    }

    public void ResetButtonClik()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseButtonClik()
    {
        _stageUI.SetActive(false);
        rectTransform.transform.DOMoveX(400f, 0.5f).OnComplete(() => Time.timeScale = 0);
    }

    public void InGameBtnClik()
    {
        _InGameTip.SetActive(true);
        Time.timeScale = 0;
    }
}
