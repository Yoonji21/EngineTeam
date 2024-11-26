using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AudioUI : MonoBehaviour
{
    [SerializeField] private GameObject settingUi;
    public bool isOnUI;


   

    public void OnClickContinue()
    {
        if (!isOnUI)
        {
            settingUi.transform.DOMoveX(950f, 0.5f);
            isOnUI = true;
        }
        else if (isOnUI)
        {
            settingUi.transform.DOMoveX(-950f, 0.5f);
            isOnUI = false;
        }
    }
}
