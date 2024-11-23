using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // fov�� 45��� 45�� �����ȿ� �ִ� asteroids�� �ν��� �� ����.
    [SerializeField] private float fov = 45f;
    // radius�� 10�̶�� ������ 10 �������� asteroids���� �ν��� �� ����.
    [SerializeField] private float radius = 10f;
    private float alertThreshold;

    [SerializeField] private List<Transform> respawnPoint;
    [SerializeField] private Respawn respawn;
    [SerializeField] private LayerMask _whatIsPlayers;



    private void Start()
    {
        alertThreshold = Mathf.Cos(fov / 2 * (Mathf.PI / 180));
    }

    private void Update()
    {
        CheckAlert();
    }

    private void CheckAlert()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius, _whatIsPlayers);

        foreach (var hit in hits)
        {
            Transform player = hit.transform;
            Vector2 targetDir = player.position - transform.position;

            // �þ߰� ���� �ִ��� Ȯ��
            float dot = Vector2.Dot(transform.up, targetDir.normalized);

            if (dot >= alertThreshold)
            {
                RaycastHit2D playerHit = Physics2D.Raycast(transform.position, targetDir, targetDir.magnitude, _whatIsPlayers);
                if (playerHit.collider != null && playerHit.collider.transform == player)
                {
                    // �÷��̾ ������

                    respawn.RespawnObject(true, player.transform);
                }
            }
        }
    }

    private void OnDrawGizmos() // �� â���� ��ä�� ���� �׸���
    {
        Gizmos.color = Color.red;

        // �þ� ���� ������ ǥ��
        Gizmos.DrawWireSphere(transform.position, radius);

        // �þ߰��� ���� ��� ���
        Vector3 leftBoundary = Quaternion.Euler(0, 0, fov / 2) * transform.up * radius;
        // �þ߰��� ������ ��� ���
        Vector3 rightBoundary = Quaternion.Euler(0, 0, -fov / 2) * transform.up * radius;

        // �þ߰��� ��輱 �׸���
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
