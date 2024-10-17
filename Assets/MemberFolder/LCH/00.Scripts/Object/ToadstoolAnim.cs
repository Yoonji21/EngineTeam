using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadstoolAnim : MonoBehaviour
{
    [SerializeField] private GameObject Element;
    [SerializeField] private GameObject[] Elements;
    private bool isOff  = false;


    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        if (Element == null)
            return;
        if (Elements == null)
            return;
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
         for(int i = 0; i< Elements.Length; i++)
        {
            Elements[i].SetActive(!isOff);
        }
    }
}
