using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadstoolAnim : MonoBehaviour
{
    [SerializeField] private GameObject Element;
    private bool isOff  = false;


    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        if(Element == null)
        {
            Element = null;
        }
    }

    public void OffDicPlayer()
    {

        if (!isOff)
        {
            _animator.SetBool("OFF", !isOff);
            isOff = true;
        }
        else 
        {
            _animator.SetBool("OFF", !isOff);
            isOff = false;
        }
    }

    public void EndAnimCall()
    {
         Element.SetActive(!isOff);
    }
}
