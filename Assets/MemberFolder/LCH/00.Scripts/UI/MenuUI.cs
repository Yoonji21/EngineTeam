using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class MenuUI : MonoBehaviour
{

    [SerializeField] private GameObject _settingUI;
    [SerializeField] private GameObject _main;
    [SerializeField] private Animator _animator;
    private Animator _currentAnimator;
   private BtnGameObjeAnim _gameObjTrigger;
    public void LevelButtonClik()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponent<Animator>();
        _currentAnimator.SetBool("IsClik", true);
        UIManager.Intance.loadTrigger.Anim = _currentAnimator;
        UIManager.Intance.PopUpOn = true;
        UIManager.Intance.loadTrigger.LoadNum = 1;
    }

    public void ExitGame()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponent<Animator>();
        _currentAnimator.SetBool("IsClik", true);
    }

    public void SettingBtn()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponent<Animator>();
        _gameObjTrigger = EventSystem.current.currentSelectedGameObject.GetComponent<BtnGameObjeAnim>();
        _currentAnimator.SetBool("IsClik", true);
        _gameObjTrigger.Anim = _currentAnimator;
        _gameObjTrigger.OnUI = _settingUI;
        _gameObjTrigger.OffUI = _main;
    }
}
