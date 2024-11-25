using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class AudioUI : MonoBehaviour
{
    [SerializeField] private GameObject settingUi;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingUi.transform.DOMoveX(-950f, 0.5f);
        }
    }

    public void OnClickContinue()
    {
        settingUi.transform.DOMoveX(950f, 0.5f);

    }
}
