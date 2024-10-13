using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[field : SerializeField]public InputSystem InputCompo { get; private set; }
    public PlayerMovement MovementCompo { get; private set; }
    

    private void Awake()
    {
        MovementCompo = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        InputCompo.OnMovementEvent += MovementCompo.GetMove;
        InputCompo.OnJumpEvent += MovementCompo.GetJump;
    }

    private void OnDisable()
    {
        InputCompo.OnMovementEvent -= MovementCompo.GetMove;
        InputCompo.OnJumpEvent -= MovementCompo.GetJump;
    }
}
