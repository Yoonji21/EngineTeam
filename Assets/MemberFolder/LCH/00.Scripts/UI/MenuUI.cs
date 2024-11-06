using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
	public void LevelButtonClik()
    {
        SceneManager.LoadScene(1);
    }
}
