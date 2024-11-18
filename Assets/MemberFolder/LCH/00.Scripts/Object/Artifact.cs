using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public float FacingDirection { get; private set; } = 1;
    private Player _player;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        FlipController(_player.MovementCompo._xMove.x);
    }

    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0, 180f, 0);
    }

    public void FlipController(float xMove)
    {
        if (Mathf.Abs(FacingDirection + xMove) < 0.5f)
            Flip();
    }
}
