using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChose : MonoBehaviour
{

    [SerializeField] private Button[] _LevelBtn;

    private void Awake()
    {
        for(int i = 1; i<_LevelBtn.Length; i++)
        {
            _LevelBtn[i].gameObject.SetActive(false);
        }
    }

    public void StageSecne(int sceneCount)
    {
        SceneManager.LoadScene(sceneCount);
    }

    public void BackButtonClik()
    {
        SceneManager.LoadScene(0);
    }
}
