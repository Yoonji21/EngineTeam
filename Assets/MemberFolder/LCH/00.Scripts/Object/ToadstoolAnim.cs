using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadstoolAnim : MonoBehaviour
{
    [SerializeField] private GameObject Element;
    [SerializeField] private GameObject[] Elements;
    [SerializeField] private GameObject OffElement;
    [SerializeField] private GameObject[] OffElements;
    public bool isON { get; set; } = false;


    private Animator _animator;
    private Player _colorPlayer;
    private Player _noColorPlayer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _colorPlayer = GameObject.FindWithTag("ColorPlayer").GetComponent<Player>();
        _noColorPlayer = GameObject.FindWithTag("NoColorPlayer").GetComponent<Player>();

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
            if (Element == null)
                return;
            if (Elements == null)
                return;
            Element.SetActive(false);
            OffElement.SetActive(true);
            for (int i = 0; i < Elements.Length; i++)
            {
                
                Elements[i].SetActive(false);
            }
            for (int i = 0; i < OffElements.Length; i++)
            {
                OffElements[i].SetActive(true);
            }
            _colorPlayer.isSwithOn = true;
            _noColorPlayer.isSwithOn = true;
        }
        else
        {
            if (Element == null)
                return;
            if (Elements == null)
                return;
            Element.SetActive(true);
            OffElement.SetActive(false);
            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i].SetActive(true);
            }
            for (int i = 0; i < OffElements.Length; i++)
            {
                OffElements[i].SetActive(false);
            }
            _colorPlayer.isSwithOn = false;
            _noColorPlayer.isSwithOn = false;
        }
    }
}
