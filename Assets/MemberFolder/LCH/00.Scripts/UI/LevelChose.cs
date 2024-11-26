using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelChose : MonoBehaviour
{

    [SerializeField] private Button[] _LevelBtn;
    [SerializeField] private StageDataSO _stageData;
    private Animator _currentAnimator;
    [SerializeField] private BtnLoadAnim _loadTrigger;
    [SerializeField] private Animator _popUpAnimator;

    private void Awake()
    {
        for(int i = _stageData.StageClear+1; i<_LevelBtn.Length; i++)
        {
            _LevelBtn[i].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        for(int i = 0; i < _stageData.StageClear; i++)
        {
            _LevelBtn[i].gameObject.SetActive(true);
        }
    }

    public void StageSecne(int sceneCount)
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponent<Animator>();
        _currentAnimator.SetBool("IsClik", true);
        _loadTrigger.Anim = _currentAnimator;
        _popUpAnimator.SetBool("PopUp", true);
        _loadTrigger.LoadNum = sceneCount;
        SceneManagers.Inatnce.CurrentSceneLevel = sceneCount -1;
        SceneManagers.Inatnce.CurrentSceneNum = sceneCount;
        UIManager.Intance.StageUI.SetActive(true);
    }

    public void BackButtonClik()
    {
        _currentAnimator = EventSystem.current.currentSelectedGameObject.GetComponent<Animator>();
        _currentAnimator.SetBool("IsClik", true);
        _loadTrigger.Anim = _currentAnimator; _popUpAnimator.SetBool("PopUp", true);
        _loadTrigger.LoadNum = 0;
        DataManger.Intance.SaveData();
    }
}
