using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System;
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
        if (isChromatlEablbe)
        {
            InputCompo.OnswithingPlayerEvent += SwitchingPlayer;
            for (int i = 0; i < _invisibleObjs.Length; i++)
                _invisibleObjs[i].SetActive(false);
           
        }
        else
        {
            InputCompo.OnswithingPlayerEvent -= SwitchingPlayer;
            for (int i = 0; i < _invisibleObjs.Length; i++)
                _invisibleObjs[i].SetActive(true);
        }
    }



    private  void OnEnable()
    {
        InputCompo.OnInteractionEvent += SwithUp;
        InputCompo.OnswithingPlayerEvent += SwitchingPlayer;
        if (_invisibleObjs == null)
        {
            return;
        }
    }



    private void OnDisable()
    {
        InputCompo.OnswithingPlayerEvent -= SwitchingPlayer;
        InputCompo.OnInteractionEvent -= SwithUp;
        if (_invisibleObjs == null)
        {
            return;
        }
    }

    public void SwithUp()
    {
        Artifact.SetActive(false);
        stateMachine.ChangeState("SwithUp");
    }

    public void SwitchingPlayer()
    {
        StartCoroutine(SwithingPlayer());
    }

    private IEnumerator SwithingPlayer()
    {
             MyPlayer(ChromatiTypes.SwithingUI, ChromatiTypes.PlayerVisual, ChromatiTypes.MyBackGround, ChromatiTypes.MyRigidbody,
            ChromatiTypes.Vcame, ChromatiTypes.MyBoxCollider, ChromatiTypes.MyMove, ChromatiTypes.MyArtifact);
            SwithinPlayerType(AchromaticTypes.SwithingPlayer, AchromaticTypes.PlayerVisual, AchromaticTypes.MyBackGround, AchromaticTypes.MyRigidbody
            , AchromaticTypes.Vcame, AchromaticTypes.MyBoxCollider, AchromaticTypes.MyMove, AchromaticTypes.MyArtifact);
        yield return new WaitForSeconds(0.5f);
        isChromatlEablbe = false;
        isAchromatlcEnable = true;
        ChromatiTypes.SwithingUI.SetActive(false);
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

    public void SwithinPlayerType(Player swithingPlayer, SpriteRenderer playerVisual, GameObject mybackGround, Rigidbody2D rbcompo, CinemachineVirtualCamera vCam, BoxCollider2D boxCollider, PlayerMovement myMove, GameObject myArtifact)
    {
        playerVisual.enabled = true;
        mybackGround.SetActive(true);
        rbcompo.bodyType = RigidbodyType2D.Dynamic;
        vCam.Follow = swithingPlayer.transform;
        boxCollider.enabled = true;
        myMove.enabled = true;
        myArtifact.SetActive(true);
    }
}
