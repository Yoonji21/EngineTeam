using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadstoolAnim : MonoBehaviour
{
     [field: SerializeField]public GameObject Element { get; set; }
    public bool isOff { get; set; } = false;


    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
