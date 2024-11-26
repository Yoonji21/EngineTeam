using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUpCtrl : MonoBehaviour
{
    private void Start()
    {
       UIManager.Intance.PopUpOn = false; 
    }
}
