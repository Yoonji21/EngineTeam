using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private List<Transform> respawnPoint;

    public void RespawnObject(bool canRespawn, Transform target)
    {
        if (canRespawn)
        {
            target.position = respawnPoint[0].transform.position;
        }
    }
}
