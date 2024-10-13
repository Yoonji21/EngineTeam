using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollderEnter : MonoBehaviour
{
    [SerializeField] private float _forceAmount;
    private Rigidbody2D _rb;

    private void Awake()
    {
        // "Ball" �±׸� ���� ������Ʈ�� Rigidbody2D�� ������
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box")) // Ư�� �±� Ȯ��
        {
            Vector2 collisionPoint = collision.contacts[0].point;
            Vector2 objectCenter = _rb.transform.position;
            float direction = collisionPoint.x - objectCenter.x;

            if (direction < 0)
            {
                _rb.AddForce(Vector2.right * _forceAmount);
                EnterCollderCoroutine(6f);
            }
            else
            {
                _rb.AddForce(Vector2.left * _forceAmount);
                EnterCollderCoroutine(6f);
            }
        }
    }

    private void EnterCollderCoroutine(float time)
    {
        StartCoroutine(EnterCollder(time));
    }

    private IEnumerator EnterCollder(float time)
    {
        yield return new WaitForSeconds(time);
       _rb.velocity = new Vector2(0, _rb.velocity.y);
    }
}
