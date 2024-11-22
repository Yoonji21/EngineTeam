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
        // ��ü�� ������ ���Ѵ�.
        Vector2 targetDir = asteroid.position - transform.position;

        if (targetDir.magnitude <= radius) // ������Ʈ�� �÷��̾��� Ž�� ������ ���� �� 
        {
            // ����
            float dot = Vector2.Dot(transform.up, targetDir.normalized);

            // ������ ���� ���� / 2 �ڻ��� ������ ũ�ٸ� => �÷��̾ �ٶ󺸴� ���⿡ �� �����ٸ�
            if (dot >= alertThreshold)
            {
                asteroid.transform.position = respawnPoint[0].transform.position;
            }
            else
            {
                //print("���� ���� x");
            }
        }
        else
        {
            //print("���� ���� x");
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
