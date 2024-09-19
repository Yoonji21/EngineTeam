using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollderEnter : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        // "Ball" 태그를 가진 오브젝트의 Rigidbody2D를 가져옴
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box")) // 특정 태그 확인
        {
            Vector2 collisionPoint = collision.contacts[0].point;
            Vector2 objectCenter = _rb.transform.position;
            float direction = collisionPoint.x - objectCenter.x;

            if (direction < 0)
            {
                _rb.AddForce(Vector2.right * 100f);
                Debug.Log("발사");
            }
            else
            {
                _rb.AddForce(Vector2.left * 100f);
                Debug.Log("발사");
            }
        }
    }
}
