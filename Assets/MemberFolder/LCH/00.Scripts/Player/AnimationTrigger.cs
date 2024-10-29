using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
	[SerializeField] private Player _palyer;

    public void AnimationEnd()
    {
        _palyer.AnimationEndTrigger();
    }
}
