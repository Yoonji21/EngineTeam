using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUpCtrl : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log(UIManager.Intance);
       // UIManager.Intance.PopUpOn = false; 
    }
}
