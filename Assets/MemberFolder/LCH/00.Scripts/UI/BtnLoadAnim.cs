using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnLoadAnim : MonoBehaviour
{
    public int LoadNum = 0;
    public Animator Anim;
    public void AnimEnd()
    {
        SceneManager.LoadScene(LoadNum);
        Anim.SetBool("IsClik", false);
    }
}
