using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnGameObjeAnim : MonoBehaviour
{
	public GameObject OnUI;
    public GameObject OffUI;
    public Animator Anim;
	public void EndTrigger()
    {
        OnUI.SetActive(true);
        Anim.SetBool("IsClik", false);
        OffUI.SetActive(false);
    }
}
