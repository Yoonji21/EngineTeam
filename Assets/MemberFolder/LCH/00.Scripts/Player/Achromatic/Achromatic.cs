using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achromatic : Player,ISwitchingPlayer
{

    public bool isExitDoor = false;

    private bool isIenable = true;

    private void OnEnable()
    {
        InputCompo.OnswithingPlayerColorEvent += SwitchingPlayer;
        InputCompo.OnJumpEvent += HandheldJump;
        InputCompo.OnInteractionEvent += SwithUp;
    }
     private void OnDisable()
    {
        InputCompo.OnswithingPlayerColorEvent -= SwitchingPlayer;
        InputCompo.OnJumpEvent -= HandheldJump;
        InputCompo.OnInteractionEvent -= SwithUp;
    }



    public void SwithUp()
    {
        if (!isSwithOn && InputCompo.isAchromatlcEnable&&IsToadstoolObj())
        {
            stateMachine.ChangeState("SwithUp");       
        }
        else if(isSwithOn && InputCompo.isAchromatlcEnable && IsToadstoolObj())
        {
            stateMachine.ChangeState("SwithDown");
        }
    }

    protected override void Update()
    {
        base.Update();
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
        MyPlayer(AchromaticTypes.SwithingUI, AchromaticTypes.PlayerVisual, AchromaticTypes.MyBackGround, AchromaticTypes.MyRigidbody,
       AchromaticTypes.Vcame, AchromaticTypes.MyBoxCollider, AchromaticTypes.MyArtifact);
        SwithinPlayerType(ChromatiTypes.SwithingPlayer, ChromatiTypes.PlayerVisual, ChromatiTypes.MyBackGround, ChromatiTypes.MyRigidbody
        , ChromatiTypes.Vcame, ChromatiTypes.MyBoxCollider, ChromatiTypes.MyArtifact);
        yield return new WaitForSeconds(0.5f);
        InputCompo.isChromatlEablbe = true;
        InputCompo.isAchromatlcEnable = false;
        AchromaticTypes.SwithingUI.SetActive(false);
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
