using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WedgePush : MonoBehaviour
{
    private Rigidbody2D _rbcompo;

    private float _originMass = 0;

    [SerializeField] private Vector2 _checkerSize;

    [SerializeField] private LayerMask _whatIsPlayer;

    private void Awake()
    {
        _rbcompo = GetComponentInParent<Rigidbody2D>();
        _originMass = _rbcompo.mass;
    }

    public bool PlayerChecker()
    {
        bool isbool = Physics2D.OverlapBox(transform.position, _checkerSize, 0, _whatIsPlayer);
        return isbool;
    }

    private void Update()
    {
        if (PlayerChecker())
        {
            Debug.Log(_originMass);
            _rbcompo.mass = 1f;
        }
        else
        {
            _rbcompo.mass = _originMass;
            _rbcompo.velocity = new Vector2(0, _rbcompo.velocity.y);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
    }
}
