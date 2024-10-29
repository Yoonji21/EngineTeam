using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
	[field : SerializeField]public InputSystem InputCompo { get; private set; }
    public PlayerMovement MovementCompo { get; private set; }

    public Rigidbody2D RbCompo { get; private set; }
    public SwitchingPlayer SwitchingCompo { get; private set; }
    
    public Interaction IntaractionCompo { get; private set; }

    public Animator AnimatorCompo { get; private set; }

    protected virtual void Awake()
    {
        RbCompo = GetComponent<Rigidbody2D>();
        AnimatorCompo = GetComponentInChildren<Animator>();
        IntaractionCompo = GetComponent<Interaction>();
        MovementCompo = GetComponent<PlayerMovement>();
        SwitchingCompo = GetComponent<SwitchingPlayer>();
    }

    private void OnEnable()
    {
        InputCompo.OnswithingPlayerEvent += SwitchingCompo.SwitchingPlayerUI;
        InputCompo.OnInteractionEvent += IntaractionCompo.InteractionPress;
    }

    private void OnDisable()
    {
        InputCompo.OnInteractionEvent -= IntaractionCompo.InteractionPress;
        InputCompo.OnswithingPlayerEvent -= SwitchingCompo.SwitchingPlayerUI;
    }
}
