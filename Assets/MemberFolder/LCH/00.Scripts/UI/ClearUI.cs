using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private StageDataSO _dataSO;
    [SerializeField] private GameObject _settingUI;
    [SerializeField] private GameObject _clearUI;
    private Animator _currentAnimator;
    private BtnGameObjeAnim _gameObjTrigger;

    public GameObject _clearShowUI;
    public GameObject _clearBackground;
    public List<GameObject> _btn;

    private void Awake()
    {
        DOTween.Init();
    }
    public void Show()
    {
        var seq = DOTween.Sequence();

        seq.Append(_clearBackground.transform.DOMoveX(960f, 0.3f)).
        Append(_clearShowUI.transform.DOMoveX(950f, 0.5f)).
         Append(_btn[0].transform.DOMoveX(950f, 0.5f))
         .Append(_btn[1].transform.DOMoveX(950f, 0.5f))
         .Append(_btn[2].transform.DOMoveX(950f, 0.5f))
         .AppendCallback(() => Time.timeScale = 0);


    }


    public void NextSceneBtn()
    {
        UIManager.Intance.isClearColor = false;
        UIManager.Intance.isClearNoColor = false;
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Animator>();
        _currentAnimator.SetBool("IsClik", true);
        UIManager.Intance.loadTrigger.Anim = _currentAnimator;
        UIManager.Intance.loadTrigger.LoadNum = SceneManagers.Inatnce.NextScene();
        UIManager.Intance.PopUpOn = true;
        if (_dataSO.StageClear < 9)
        {
            _dataSO.StageClear = SceneManagers.Inatnce.CurrentSceneLevel;
        }
        DataManger.Intance.SaveData();
        SceneManagers.Inatnce.CurrentSceneLevel++;
        Time.timeScale = 1;
    }

    internal void ShowLast()
    {
        var seq = DOTween.Sequence();

        seq.Append(_clearBackground.transform.DOMoveX(960f, 0.3f)).
        Append(_clearShowUI.transform.DOMoveX(950f, 0.5f)).
         Append(_btn[0].transform.DOMoveX(950f, 0.5f))
         .Append(_btn[1].transform.DOMoveX(950f, 0.5f))
         .AppendCallback(() => Time.timeScale = 0);
    }

    public void SelectLevel()
    {
        UIManager.Intance.isClearColor = false;
        UIManager.Intance.isClearNoColor = false;
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Animator>();
        _currentAnimator.SetBool("IsClik", true);
        UIManager.Intance.loadTrigger.Anim = _currentAnimator;
        UIManager.Intance.loadTrigger.LoadNum = 1;
        if (_dataSO.StageClear < 9)
        {
            _dataSO.StageClear = SceneManagers.Inatnce.CurrentSceneLevel;
        }
        UIManager.Intance.PopUpOn = true;
        UIManager.Intance.StageUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void SettingBtn()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Animator>();
        _gameObjTrigger = EventSystem.current.currentSelectedGameObject.GetComponentInParent<BtnGameObjeAnim>();
        _currentAnimator.SetBool("IsClik", true);
        _gameObjTrigger.Anim = _currentAnimator;
        _gameObjTrigger.OnUI = _settingUI;
        _gameObjTrigger.OffUI = _clearUI;
    }
}

