using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float def;
    public Transform laserPoint;
    public LineRenderer linerenderer;
    private Transform _transform;

    public LayerMask target;

    [SerializeField] private Respawn respawn;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();   
    }

    private bool DrawwRaw()
    {
        bool isPlayer = Physics2D.Raycast(transform.position, transform.right, target);
        return isPlayer;
    }

    private void ShootLaser()
    {
        if (DrawwRaw())
        {
            respawn.RespawnObject(true);
        }
        else
        {
            Draw2DRay(laserPoint.position, laserPoint.transform.right * def);
        }
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        linerenderer.SetPosition(0, startPos);
        linerenderer.SetPosition(1, endPos);
    }
}
