using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPush : MonoBehaviour
{
    private Rigidbody2D _rbCompo;

    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private float _size;

    private void Awake()
    {
        _rbCompo = GetComponent<Rigidbody2D>();
    }

    public bool PlayerChecker()
    {
        bool isbool = Physics2D.OverlapCircle(transform.position, _size, _whatIsPlayer);
        return isbool;
    }

    private void Update()
    {
        if (!PlayerChecker())
        {
            _rbCompo.velocity = new Vector2(0, _rbCompo.velocity.y);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,_size);
    }

}
