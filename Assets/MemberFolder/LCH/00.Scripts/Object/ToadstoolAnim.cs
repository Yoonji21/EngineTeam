using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadstoolAnim : MonoBehaviour
{
    [SerializeField] private GameObject Element;
    [SerializeField] private GameObject[] Elements;
    public bool isON { get; set; } = false;


    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        if (Element == null)
            return;
        if (Elements == null)
            return;
    }

    private void Update()
    {
        OffDicPlayer();
    }
    

    public void OffDicPlayer()
    {

        if (isON)
        {
            _animator.SetBool("ON", true);
        }
        else 
        {
            _animator.SetBool("ON", false);
        }
    }

    public void EndAnimCall()
    {
        if (isON)
        {
            Element.SetActive(false);
            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i].SetActive(false);
            }
        }
        else
        {
            Element.SetActive(true);
            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i].SetActive(true);
            }
        }
    }
}
