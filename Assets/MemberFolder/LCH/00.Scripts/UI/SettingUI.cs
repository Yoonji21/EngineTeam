using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class SettingUI : MonoBehaviour
{

    [SerializeField] private GameObject _settingUI;
    [SerializeField] private GameObject _main;
    [SerializeField] private StageDataSO _dataSO;
    private bool _isOn;
    private Animator _currentAnimator;
    private BtnLoadAnim _loadTrigger;
    private BtnGameObjeAnim _gameObjTrigger;
    private BtnAnim _animTrigger;

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame&&_isOn)
        {
            _settingUI.SetActive(true);
            _isOn = false;
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame && !_isOn)
        {
            _settingUI.SetActive(false);
            _isOn = true;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void BackBtn()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponent<Animator>();
        _gameObjTrigger = EventSystem.current.currentSelectedGameObject.GetComponent<BtnGameObjeAnim>();
        _currentAnimator.SetBool("IsClik", true);
        _gameObjTrigger.Anim = _currentAnimator;
        _gameObjTrigger.OnUI = _main;
        _gameObjTrigger.OffUI = _settingUI;
    }

    public void GameReSet()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponent<Animator>();
        _animTrigger = EventSystem.current.currentSelectedGameObject.GetComponent<BtnAnim>();
        _animTrigger.Anim = _currentAnimator;
        _currentAnimator.SetBool("IsClik", true);
        _dataSO.StageClear = 0;
    }

    public void LevelAllUnLock()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponent<Animator>();
        _animTrigger = EventSystem.current.currentSelectedGameObject.GetComponent<BtnAnim>();
        _animTrigger.Anim = _currentAnimator;
        _currentAnimator.SetBool("IsClik", true);
        _dataSO.StageClear = 9;
    }

    public void ExitGame()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponent<Animator>();
        _currentAnimator.SetBool("IsClik", true);
    }
}
