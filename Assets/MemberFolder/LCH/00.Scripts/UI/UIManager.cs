using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Intance;

    public bool isClearColor;
    public bool isClearNoColor;

    [SerializeField] private ClearUI _clearUiOpen;

    private void Awake()
    {
        if (Intance == null)
            Intance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(isClearColor && isClearNoColor)
        {
            _clearUiOpen.gameObject.SetActive(true);
        }
    }


}
