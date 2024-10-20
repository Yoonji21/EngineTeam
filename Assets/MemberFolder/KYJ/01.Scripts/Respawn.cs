using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private List<Transform> respawnPoint;
    [SerializeField] private GameObject target;

    public void RespawnObject(bool canRespawn)
    {
        if (canRespawn)
        {
            target.transform.position = respawnPoint[0].transform.position;
        }
    }
}
