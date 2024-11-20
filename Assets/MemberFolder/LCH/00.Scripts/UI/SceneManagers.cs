using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
	public static SceneManagers Inatnce;
    public int CurrentSceneNum;
    public int CurrentSceneLevel;
    private void Awake()
    {
        if (Inatnce == null)
            Inatnce = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public int NextScene()
    {
        return CurrentSceneNum + 1;
    }
}
