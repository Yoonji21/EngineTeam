using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Key : MonoBehaviour
{ 
    public void DestroyKey()
    {
        Destroy(gameObject);
    }
}