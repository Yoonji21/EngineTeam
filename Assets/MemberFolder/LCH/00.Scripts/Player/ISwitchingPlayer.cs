using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public interface ISwitchingPlayer
{
    public void MyPlayer(GameObject UI, SpriteRenderer player, GameObject mybackGround,
        Rigidbody2D rbcompo, CinemachineVirtualCamera vCam, BoxCollider2D boxCollider,
        GameObject Artifact);

    public void SwithinPlayerType(Player swithingPlayer, SpriteRenderer player, GameObject mybackGround,
        Rigidbody2D rbcompo, CinemachineVirtualCamera vCam, BoxCollider2D boxCollider,
        GameObject Artifact);
}
