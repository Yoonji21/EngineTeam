using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPush : MonoBehaviour
{
	private Rigidbody2D _rbCompo;
    [SerializeField] private Vector2 _checkerSize;

    [SerializeField] private LayerMask _whatIsPlayer;

    private void Awake()
    {
        _rbCompo = GetComponent<Rigidbody2D>();
    }

    public bool PlayerChecker()
    {
        bool isbool = Physics2D.OverlapBox(transform.position, _checkerSize, 0, _whatIsPlayer);
        return isbool;
    }

    private void Update()
    {
        if(!PlayerChecker())
        {
            _rbCompo.velocity = new Vector2(0, _rbCompo.velocity.y);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
    }

}
