using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public interface ISwitchingPlayer
{
    public void MyPlayer(GameObject UI, SpriteRenderer player, GameObject mybackGround,
        Rigidbody2D rbcompo, CinemachineVirtualCamera vCam, BoxCollider2D boxCollider, PlayerMovement myMove,
        GameObject Artifact);

    public void SwithinPlayer(Player swithingPlayer, SpriteRenderer player, GameObject mybackGround,
        Rigidbody2D rbcompo, CinemachineVirtualCamera vCam, BoxCollider2D boxCollider, PlayerMovement myMove,
        GameObject Artifact);
}
