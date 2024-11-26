using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AudioUI : MonoBehaviour
{
    [SerializeField] private GameObject settingUi;

    private RectTransform rectTransform;
    public bool isOnUI;

    private void Awake()
    {
        rectTransform = settingUi.GetComponent<RectTransform>();
    }


    public void OnClickContinue()
    {
        if (!isOnUI)
        {
            rectTransform.DOMoveX(950f, 0.5f);
            isOnUI = true;
        }
        else if (isOnUI)
        {
            rectTransform.transform.DOMoveX(-950f, 0.5f);
            isOnUI = false;
        }
    }
}
