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

    public Transform asteroid;

    [SerializeField] private List<Transform> respawnPoint;



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
        // 물체의 방향을 구한다.
        Vector2 targetDir = asteroid.position - transform.position;

        if (targetDir.magnitude <= radius) // 오브젝트가 플레이어의 탐지 범위에 들어올 때 
        {
            // 내적
            float dot = Vector2.Dot(transform.up, targetDir.normalized);

            // 내적한 값이 각도 / 2 코사인 값보다 크다면 => 플레이어가 바라보는 방향에 더 가깝다면
            if (dot >= alertThreshold)
            {
                asteroid.transform.position = respawnPoint[0].transform.position;
            }
            else
            {
                //print("범위 감지 x");
            }
        }
        else
        {
            //print("범위 감지 x");
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
