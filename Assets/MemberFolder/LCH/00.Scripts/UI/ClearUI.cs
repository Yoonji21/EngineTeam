using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour
{
    [SerializeField] private StageDataSO _dataSO;
    [SerializeField] private GameObject _settingUI;
    [SerializeField] private GameObject _clearUI;
    private Animator _currentAnimator;
    private BtnLoadAnim _loadTrigger;
    private BtnGameObjeAnim _gameObjTrigger;

    private void Awake()
    {
        _clearUI.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void NextSceneBtn()
    {
        _clearUI.SetActive(false);
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Animator>();
        _loadTrigger = EventSystem.current.currentSelectedGameObject.GetComponentInParent<BtnLoadAnim>();
        _currentAnimator.SetBool("IsClik", true);
        _loadTrigger.Anim = _currentAnimator;
        _loadTrigger.LoadNum = SceneManagers.Inatnce.NextScene();
        if (_dataSO.StageClear < 9)
        {
            _dataSO.StageClear = SceneManagers.Inatnce.CurrentSceneLevel;
        }
        DataManger.Intance.SaveData();
        SceneManagers.Inatnce.CurrentSceneLevel++;
        UIManager.Intance.isClearColor = false;
        UIManager.Intance.isClearNoColor = false;
       
    }

    public void SelectLevel()
    {
        _clearUI.SetActive(false);
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Animator>();
        _loadTrigger = EventSystem.current.currentSelectedGameObject.GetComponentInParent<BtnLoadAnim>();
        _currentAnimator.SetBool("IsClik", true);
        _loadTrigger.Anim = _currentAnimator;
        _loadTrigger.LoadNum = 1;
        if (_dataSO.StageClear < 9)
        {
            _dataSO.StageClear = SceneManagers.Inatnce.CurrentSceneLevel;
        }
        _clearUI.SetActive(false);
        UIManager.Intance.StageUI.SetActive(false);
        UIManager.Intance.isClearColor = false;
        UIManager.Intance.isClearNoColor = false;
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

