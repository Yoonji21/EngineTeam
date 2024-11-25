using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{

    [SerializeField] private GameObject _stageUI;
    [SerializeField] private GameObject _pauseUI;
    private Animator _currentAnimator;
    private BtnLoadAnim _loadTrigger;
    private BtnGameObjeAnim _gameObjTrigger;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ContinuationButtonClik()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Animator>();
        _gameObjTrigger = EventSystem.current.currentSelectedGameObject.GetComponentInParent<BtnGameObjeAnim>();
        _currentAnimator.SetBool("IsClik", true);
        _gameObjTrigger.Anim = _currentAnimator;
        _gameObjTrigger.OnUI = _stageUI;
        _gameObjTrigger.OffUI = _pauseUI;
        Time.timeScale = 1;
    }

    public void LevelSelectButtonClik()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Animator>();
        _loadTrigger = EventSystem.current.currentSelectedGameObject.GetComponentInParent<BtnLoadAnim>();
        _currentAnimator.SetBool("IsClik", true);
        _loadTrigger.Anim = _currentAnimator;
        _loadTrigger.LoadNum = 1;
        _stageUI.SetActive(false);
        _pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButtonClik()
    {

        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Animator>();
        _loadTrigger = EventSystem.current.currentSelectedGameObject.GetComponentInParent<BtnLoadAnim>();
        _currentAnimator.SetBool("IsClik", true);
        _loadTrigger.Anim = _currentAnimator;
        _loadTrigger.LoadNum = 0;
        _pauseUI.SetActive(false);
        _stageUI.SetActive(false);
        Time.timeScale = 1;
    }
}
