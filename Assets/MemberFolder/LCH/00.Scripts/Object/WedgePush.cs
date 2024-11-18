using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WedgePush : MonoBehaviour
{
    private Rigidbody2D _rbcompo;

    private float _originMass = 0;

    [SerializeField] private float _raydirect;

    [SerializeField] private Transform _cherkerTrm;

    [SerializeField] private LayerMask _whatIsPlayer;

    private void Awake()
    {
        _rbcompo = GetComponentInParent<Rigidbody2D>();
        _originMass = _rbcompo.mass;
    }

    public RaycastHit2D PlayerChecker()
    {
      return Physics2D.Raycast(_cherkerTrm.position, Vector2.right, _raydirect, _whatIsPlayer);
    }

    private void Update()
    {
        if (PlayerChecker())
        {
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
        Gizmos.DrawRay(_cherkerTrm.position, Vector2.right * _raydirect);

    }
}
