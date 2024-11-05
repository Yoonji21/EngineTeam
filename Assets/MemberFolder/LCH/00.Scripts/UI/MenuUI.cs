using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
	[SerializeField] private Canvas _levelUI;

	public void LevelButtonClik()
    {
        gameObject.SetActive(false);
        _levelUI.gameObject.SetActive(true);
    }
}
