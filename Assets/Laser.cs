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
        // �÷��̾�� �� ���̾��ũ ���� (���̾� �̸��� Unity���� ������ �̸��� ����ϼ���)

        // �÷��̾�� ���� �����ϴ� Raycast
        hit = Physics2D.Raycast(laserPoint.position, transform.right, Mathf.Infinity, target);

        // �������� �÷��̾ ���� ��Ҵ��� ���� ��ȯ
        return hit.collider != null;
    }

    private void ShootLaser()
    {
        RaycastHit2D hit;

        // �������� �÷��̾ ���� ����� ��
        if (DrawwRaw(out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // �÷��̾ ������ �� ������ ó��
                respawn.RespawnObject(true);
            }

            // �������� ���� �������� �׸���
            Draw2DRay(laserPoint.position, hit.transform.position);
        }
        else
        {
            // �ƹ��͵� ���� �ʾ��� ��� �⺻ �������� ������ �׸���
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
