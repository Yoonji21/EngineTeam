using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObj : MonoBehaviour
{
	private Rigidbody2D _rbComp;

    private void Awake()
    {
        _rbComp = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어");
            if(_rbComp.constraints == RigidbodyConstraints2D.FreezePositionX)
            {
                Debug.Log("꺼버려");
                _rbComp.constraints = RigidbodyConstraints2D.None;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _rbComp.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}
