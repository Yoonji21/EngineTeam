using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChose : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void StageSecne(int sceneCount)
    {
        SceneManager.LoadScene(sceneCount);
    }
}
