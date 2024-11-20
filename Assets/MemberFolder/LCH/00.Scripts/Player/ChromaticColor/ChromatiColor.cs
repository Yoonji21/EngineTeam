using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromatiColor : Player,ISwitchingPlayer
{
    private GameObject[] _invisibleObjs;
    [field:SerializeField] public GameObject Artifact;
    public bool isExitDoor = false;

    private Entity _entity;

    protected override void AfterInit()
    {
        base.AfterInit();
        _invisibleObjs = GameObject.FindGameObjectsWithTag("InvisibleObj");
    }

    protected override void Update()
    {
        base.Update();
    }



    protected override  void OnEnable()
    {
        base.OnEnable();
        InputCompo.OnInteractionEvent += SwithUp;
        if (_invisibleObjs == null)
        {
            return;
        }

        for (int i = 0; i < _invisibleObjs.Length; i++)
            _invisibleObjs[i].SetActive(false);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        InputCompo.OnInteractionEvent -= SwithUp;
        if (_invisibleObjs == null)
        {
            return;
        }

        for (int i = 0; i < _invisibleObjs.Length; i++)
            _invisibleObjs[i].SetActive(true);
    }

    public void SwithUp()
    {
        Artifact.SetActive(false);
        stateMachine.ChangeState("SwithUp");
    }

    public void MyPlayer(GameObject UI, SpriteRenderer playerVisual, GameObject mybackGround, Rigidbody2D rbcompo, CinemachineVirtualCamera vCam, BoxCollider2D boxCollider, PlayerMovement myMove, GameObject myArtifact)
    {
        UI.SetActive(true);
        playerVisual.enabled = false;
        mybackGround.SetActive(false);
        rbcompo.bodyType = RigidbodyType2D.Static;
        vCam.Follow = null;
        boxCollider.enabled = false;
        myMove.enabled = false;
        myArtifact.SetActive(false);
        
    }

    public void SwithinPlayer(Player swithingPlayer, SpriteRenderer playerVisual, GameObject mybackGround, Rigidbody2D rbcompo, CinemachineVirtualCamera vCam, BoxCollider2D boxCollider, PlayerMovement myMove, GameObject myArtifact)
    {
        playerVisual.enabled = true;
        mybackGround.SetActive(true);
        rbcompo.bodyType = RigidbodyType2D.Static;
        vCam.Follow = swithingPlayer.transform;
        boxCollider.enabled = true;
        myMove.enabled = true;
        myArtifact.SetActive(true);
    }
}
