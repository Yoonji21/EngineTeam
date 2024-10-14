using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[field : SerializeField]public InputSystem InputCompo { get; private set; }
    public PlayerMovement MovementCompo { get; private set; }
    public SwitchingPlayer SwitchingCompo { get; private set; }

    public Toadstool offPlayerDicCompo { get; private set; }
    

    private void Awake()
    {
        MovementCompo = GetComponent<PlayerMovement>();
        SwitchingCompo = GetComponent<SwitchingPlayer>();
        offPlayerDicCompo = FindAnyObjectByType<Toadstool>();
    }

    private void OnEnable()
    {
        InputCompo.OnMovementEvent += MovementCompo.GetMove;
        InputCompo.OnJumpEvent += MovementCompo.GetJump;
        InputCompo.OnswithingPlayerEvent += SwitchingCompo.SwitchingPlayerUI;
        if (offPlayerDicCompo != null)
        {
            InputCompo.OnInteractionEvent += offPlayerDicCompo.offPlayerDic;
        }
    }

    private void OnDisable()
    {
        if (offPlayerDicCompo != null)
        {
            InputCompo.OnInteractionEvent -= offPlayerDicCompo.offPlayerDic;
        }
        InputCompo.OnswithingPlayerEvent -= SwitchingCompo.SwitchingPlayerUI;
        InputCompo.OnMovementEvent -= MovementCompo.GetMove;
        InputCompo.OnJumpEvent -= MovementCompo.GetJump;
    }
}
