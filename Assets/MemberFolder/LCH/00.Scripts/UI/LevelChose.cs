using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChose : MonoBehaviour
{
    public void StageSecne(int sceneCount)
    {
        SceneManager.LoadScene(sceneCount);
    }
}
