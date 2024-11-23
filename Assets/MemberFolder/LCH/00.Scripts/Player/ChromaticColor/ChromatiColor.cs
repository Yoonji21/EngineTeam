using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ChromatiColor : Player,ISwitchingPlayer
{
    private GameObject[] _invisibleObjs;
    public bool isExitDoor = false;
    [SerializeField] private GameObject _artifact;

    private Entity _entity;

    protected override void AfterInit()
    {
        base.AfterInit();
        _invisibleObjs = GameObject.FindGameObjectsWithTag("InvisibleObj");
    }

    protected override void Update()
    {
        base.Update();
        if (InputCompo.isChromatlEablbe)
        {
           
            for (int i = 0; i < _invisibleObjs.Length; i++)
                _invisibleObjs[i].SetActive(false);
           
        }
        else
        {
            for (int i = 0; i < _invisibleObjs.Length; i++)
                _invisibleObjs[i].SetActive(true);
        }
    }

    private void Start()
    {
        SwitchingPlayer();
    }

    private  void OnEnable()
    {
        InputCompo.OnJumpEvent += HandheldJump;
        InputCompo.OnInteractionEvent += SwithUp;
        InputCompo.OnswithingPlayerNoColorEvent += SwitchingPlayer;
        if (_invisibleObjs == null)
        {
            return;
        }
    }



    private void OnDisable()
    {
        InputCompo.OnInteractionEvent -= SwithUp;
        InputCompo.OnJumpEvent -= HandheldJump;
        InputCompo.OnswithingPlayerNoColorEvent -= SwitchingPlayer;
        if (_invisibleObjs == null)
        {
            return;
        }
    }

    public void SwithUp()
    {
        Debug.Log(isSwithOn);
        if (!isSwithOn&&InputCompo.isChromatlEablbe && IsToadstoolObj())
        {
            Artifact.SetActive(false);
            isChromatilColorArtifact = true;
            stateMachine.ChangeState("SwithUp");
        }
        else if(isSwithOn && InputCompo.isChromatlEablbe && IsToadstoolObj())
        {
            Artifact.SetActive(false);
            isChromatilColorArtifact = true;
            stateMachine.ChangeState("SwithDown");
        }
    }

    public void SwitchingPlayer()
    {
        if (isSwithingPlayer)
        {
            StartCoroutine(SwithingPlayer());
        }
    }

    private IEnumerator SwithingPlayer()
    {
        InputCompo.isChromatlEablbe = false;
        InputCompo.isAchromatlcEnable = true;
        MyPlayer(ChromatiTypes.SwithingUI, ChromatiTypes.PlayerVisual, ChromatiTypes.MyBackGround, ChromatiTypes.MyRigidbody,
        ChromatiTypes.Vcame, ChromatiTypes.MyBoxCollider, ChromatiTypes.MyArtifact);
       SwithinPlayerType(AchromaticTypes.SwithingPlayer, AchromaticTypes.PlayerVisual, AchromaticTypes.MyBackGround, AchromaticTypes.MyRigidbody
       , AchromaticTypes.Vcame, AchromaticTypes.MyBoxCollider, AchromaticTypes.MyArtifact);
        yield return new WaitForSeconds(0.5f);
        ChromatiTypes.SwithingUI.SetActive(false);
    }

    public void MyPlayer(GameObject UI, SpriteRenderer playerVisual, GameObject mybackGround, Rigidbody2D rbcompo, CinemachineVirtualCamera vCam, BoxCollider2D boxCollider,  GameObject myArtifact)
    {
        UI.SetActive(true);
        playerVisual.enabled = false;
        mybackGround.SetActive(false);
        rbcompo.bodyType = RigidbodyType2D.Static;
        vCam.Follow = null;
        boxCollider.isTrigger = true;
        myArtifact.SetActive(false);
    }

    public void SwithinPlayerType(Player swithingPlayer, SpriteRenderer playerVisual, GameObject mybackGround, Rigidbody2D rbcompo, CinemachineVirtualCamera vCam, BoxCollider2D boxCollider, GameObject myArtifact)
    {
        playerVisual.enabled = true;
        mybackGround.SetActive(true);
        rbcompo.bodyType = RigidbodyType2D.Dynamic;
        vCam.Follow = swithingPlayer.transform;
        boxCollider.isTrigger = false;
        myArtifact.SetActive(true);
    }
}
