using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Intance;

    public bool isClearColor;
    public bool isClearNoColor;

    [SerializeField] private GameObject _clearUiOpen;
    [SerializeField] private GameObject _lastStageClear;
    [SerializeField] public GameObject StageUI;

    private void Awake()
    {
        if (Intance == null)
            Intance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(isClearColor && isClearNoColor)
        {
            if(SceneManagers.Inatnce.CurrentSceneLevel < 9)
            {
                _clearUiOpen.SetActive(true);
            }
            else
            {
                _lastStageClear.SetActive(true);
            }
        }
    }


}
