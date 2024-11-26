using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Intance;

    public bool isClearColor;
    public bool isClearNoColor;
    public bool PopUpOn;

    [SerializeField] private ClearUI _clearUi;
    [SerializeField] private GameObject _lastStageClear;
    [SerializeField] public GameObject StageUI;
    [SerializeField] private TextMeshProUGUI _stageText;
    [SerializeField] private TextMeshProUGUI _lastStageText;
    [field:SerializeField] public BtnLoadAnim loadTrigger;

    private void Awake()
    {
        if (Intance == null)
        {
            Intance = this;
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if(isClearColor && isClearNoColor)
        {
            if(SceneManagers.Inatnce.CurrentSceneLevel < 10)
            {
                _stageText.text = $"Stage {SceneManagers.Inatnce.CurrentSceneLevel} Clear";
                _clearUi.Show();
            }
            else
            {
                _lastStageText.text = $"Stage {SceneManagers.Inatnce.CurrentSceneLevel} Clear";
                _lastStageClear.SetActive(true);
            }
        }
    }


}
