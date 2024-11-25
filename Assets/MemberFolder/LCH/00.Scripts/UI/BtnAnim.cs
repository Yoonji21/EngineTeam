using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAnim : MonoBehaviour
{
	public Animator Anim;

	public void AnimTrigger()
    {
        Anim.SetBool("IsClik", false);
    }
}
