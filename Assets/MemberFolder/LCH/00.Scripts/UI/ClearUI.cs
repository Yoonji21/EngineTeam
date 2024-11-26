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
    private bool isEnd;

    private void Awake()
    {
        DOTween.Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Show();
        }
    }

    public void Show()
    {
        var seq = DOTween.Sequence();

        seq.Append(_clearBackground.transform.DOMoveX(960f, 0.3f)).
        Append(_clearShowUI.GetComponent<RectTransform>().transform.DOMoveX(950f, 0.5f)).
         Append(_btn[0].GetComponent<RectTransform>().transform.DOMoveX(950f, 0.5f))
         .Append(_btn[1].GetComponent<RectTransform>().transform.DOMoveX(950f, 0.5f))
         .Append(_btn[2].GetComponent<RectTransform>().transform.DOMoveX(950f, 0.5f))
         .AppendCallback(() => ClearUIEnd());
    }

    private void ClearUIEnd()
    {
        Time.timeScale = 1f;
        isEnd = true;
    }

    public void NextSceneBtn()
    {
        if (isEnd)
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

            if(_btn.Count >= 3)
            {
                HideBtn3();
            }
            else
            {
                HideBtn2();
            }

            isEnd = false;  
        }
    }

    internal void ShowLast()
    {
        var seq = DOTween.Sequence();

        seq.Append(_clearShowUI.GetComponent<RectTransform>().transform.DOMoveX(950f, 0.3f)).
         Append(_btn[0].GetComponent<RectTransform>().transform.DOMoveX(950f, 0.3f))
         .Append(_btn[1].GetComponent<RectTransform>().transform.DOMoveX(950f, 0.3f)).
         Append(_clearBackground.GetComponent<RectTransform>().transform.DOMoveX(960f, 0.2f))
         .AppendCallback(() => ClearUIEnd());
    }

    public void SelectLevel()
    {
        if (isEnd)
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

            if (_btn.Count >= 3)
            {
                HideBtn3();
            }
            else
            {
                HideBtn2();
            }
            isEnd = false;
        }
    }

    public void HideBtn2()
    {
        Time.timeScale = 1;

        var seq = DOTween.Sequence();

        seq.Append(_clearShowUI.GetComponent<RectTransform>().transform.DOMoveX(-1200f, 0.3f)).
         Append(_btn[0].GetComponent<RectTransform>().transform.DOMoveX(-1200f, 0.3f))
         .Append(_btn[1].GetComponent<RectTransform>().transform.DOMoveX(-1200f, 0.3f)).
         Append(_clearBackground.GetComponent<RectTransform>().transform.DOMoveX(-1200f, 0.2f));
    }

    public void HideBtn3()
    {
        Time.timeScale = 1;

        var seq = DOTween.Sequence();

        seq.Append(_clearShowUI.GetComponent<RectTransform>().transform.DOMoveX(-1200f, 0.3f)).
         Append(_btn[0].GetComponent<RectTransform>().transform.DOMoveX(-1200f, 0.3f))
         .Append(_btn[1].GetComponent<RectTransform>().transform.DOMoveX(-1200f, 0.3f))
         .Append(_btn[2].GetComponent<RectTransform>().transform.DOMoveX(-1200f, 0.3f)).
         Append(_clearBackground.GetComponent<RectTransform>().transform.DOMoveX(-1200f, 0.2f));
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

