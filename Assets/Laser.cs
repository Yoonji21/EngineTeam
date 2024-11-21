using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Laser : MonoBehaviour
{
    #region
    [SerializeField] private float def;
    public Transform laserPoint;
    public LineRenderer linerenderer;

    public LayerMask target;

    private Transform m_transform;

    [SerializeField] private Respawn respawn;


    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();
    }

    private bool DrawwRaw(out RaycastHit2D hit)
    {
        // 플레이어와 벽 레이어마스크 설정 (레이어 이름은 Unity에서 설정된 이름을 사용하세요)

        // 플레이어와 벽을 감지하는 Raycast
        hit = Physics2D.Raycast(laserPoint.position, transform.right, Mathf.Infinity, target);

        // 레이저가 플레이어나 벽에 닿았는지 여부 반환
        return hit.collider != null;
    }

    private void ShootLaser()
    {
        RaycastHit2D hit;

        // 레이저가 플레이어나 벽에 닿았을 때
        if (DrawwRaw(out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // 플레이어를 맞췄을 때 리스폰 처리
                respawn.RespawnObject(true);
            }

            // 레이저를 닿은 지점까지 그리기
            Draw2DRay(laserPoint.position, hit.transform.position);
        }
        else
        {
            // 아무것도 맞지 않았을 경우 기본 방향으로 레이저 그리기
            Draw2DRay(laserPoint.position, transform.right * def);
        }
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        //if (transform.rotation.z == -90)
        //{
        //    linerenderer.SetPosition(0, new Vector2(startPos.x, startPos.y));
        //    linerenderer.SetPosition(1, new Vector2(startPos.x, endPos.y));
        //    print("90");
        //}

        linerenderer.SetPosition(0, startPos);
        linerenderer.SetPosition(1, endPos);

        print("d");
    }

    #endregion

}
