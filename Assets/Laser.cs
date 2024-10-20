using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float def;
    public Transform laserPoint;
    public LineRenderer linerenderer;
    private Transform _transform;

    public LayerMask agent;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();   
    }

    private void ShootLaser()
    {
        if (Physics2D.Raycast(_transform.position, transform.right, agent))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserPoint.position, transform.right);
            Draw2DRay(laserPoint.position, _hit.point);
            print("dd");
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
