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

    [field: SerializeField] public GameObject settingUI;
    [SerializeField] private ClearUI _clearUi;
    [SerializeField] private ClearUI _lastStageClear;
    [SerializeField] public GameObject StageUI;
    [SerializeField] private TextMeshProUGUI _stageText;
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
                _stageText.text = $"Level {SceneManagers.Inatnce.CurrentSceneLevel} Clear";
                _clearUi.Show();
                isClearColor = false;
                isClearNoColor = false;
            }
            else
            {
                _stageText.text = $"Level {SceneManagers.Inatnce.CurrentSceneLevel} Clear";
                _lastStageClear.ShowLast();
                isClearColor = false;
                isClearNoColor = false;
            }
        }
    }


}
