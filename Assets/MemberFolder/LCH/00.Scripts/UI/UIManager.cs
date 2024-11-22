using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Intance;

    public bool isClearColor;
    public bool isClearNoColor;

    [SerializeField] private ClearUI _clearUiOpen;
    [SerializeField] private ClearUI _lastStageClear;

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
                _clearUiOpen.gameObject.SetActive(true);
            }
            else
            {
                _lastStageClear.gameObject.SetActive(true);
            }
        }
    }


}
