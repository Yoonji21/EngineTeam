using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // fov가 45라면 45도 각도안에 있는 asteroids를 인식할 수 있음.
    [SerializeField] private float fov = 45f;
    // radius가 10이라면 반지름 10 범위에서 asteroids들을 인식할 수 있음.
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

            // 시야각 내에 있는지 확인
            float dot = Vector2.Dot(transform.up, targetDir.normalized);

            if (dot >= alertThreshold)
            {
                RaycastHit2D playerHit = Physics2D.Raycast(transform.position, targetDir, targetDir.magnitude, _whatIsPlayers);
                if (playerHit.collider != null && playerHit.collider.transform == player)
                {
                    // 플레이어가 감지됨

                    respawn.RespawnObject(true, player.transform);
                }
            }
        }
    }

    private void OnDrawGizmos() // 씬 창에서 부채꼴 범위 그리기
    {
        Gizmos.color = Color.red;

        // 시야 범위 반지름 표시
        Gizmos.DrawWireSphere(transform.position, radius);

        // 시야각의 왼쪽 경계 계산
        Vector3 leftBoundary = Quaternion.Euler(0, 0, fov / 2) * transform.up * radius;
        // 시야각의 오른쪽 경계 계산
        Vector3 rightBoundary = Quaternion.Euler(0, 0, -fov / 2) * transform.up * radius;

        // 시야각의 경계선 그리기
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
