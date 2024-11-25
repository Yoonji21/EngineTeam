using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnExit : MonoBehaviour
{
	public void EndAnim()
    {
        DataManger.Intance.SaveData();
        Application.Quit();
    }
}
