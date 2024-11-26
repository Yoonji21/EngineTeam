using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PauseUI : MonoBehaviour
{

    [SerializeField] private GameObject _stageUI;
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private GameObject _pauseUIRect;
    private Animator _currentAnimator;
    [SerializeField] private BtnLoadAnim _loadTrigger;
    private BtnGameObjeAnim _gameObjTrigger;
    [SerializeField] private Animator _popUpAniamtor;


    private RectTransform rectTransform;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        rectTransform = _pauseUIRect.GetComponent<RectTransform>();

    }

    public void ContinuationButtonClik()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Animator>();
        _gameObjTrigger = EventSystem.current.currentSelectedGameObject.GetComponentInParent<BtnGameObjeAnim>();
        _currentAnimator.SetBool("IsClik", true);
        _gameObjTrigger.Anim = _currentAnimator;
        _gameObjTrigger.OnUI = _stageUI;
        _gameObjTrigger.OffUI = _pauseUI;
        rectTransform.transform.DOMoveX(-400f, 0.5f);

        Time.timeScale = 1;
    }

    public void LevelSelectButtonClik()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Animator>();
        _currentAnimator.SetBool("IsClik", true);
        _loadTrigger.Anim = _currentAnimator;
        _loadTrigger.LoadNum = 1;
        _popUpAniamtor.SetBool("PopUp", true);
        _stageUI.SetActive(false);
        rectTransform.transform.DOMoveX(-400f, 0.5f);

        Time.timeScale = 1;
        UIManager.Intance.PopUpOn = true;
    }

    public void MainMenuButtonClik()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponentInParent<Animator>();
        _currentAnimator.SetBool("IsClik", true);
        _loadTrigger.Anim = _currentAnimator;
        _loadTrigger.LoadNum = 0;
        _popUpAniamtor.SetBool("PopUp", true);
        _stageUI.SetActive(false);
        rectTransform.transform.DOMoveX(-400f, 0.5f);

        Time.timeScale = 1;
        UIManager.Intance.PopUpOn = true;
    }
}
