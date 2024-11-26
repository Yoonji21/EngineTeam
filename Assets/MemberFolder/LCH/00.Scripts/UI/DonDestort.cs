using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonDestort : MonoBehaviour
{
    public static DonDestort Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
