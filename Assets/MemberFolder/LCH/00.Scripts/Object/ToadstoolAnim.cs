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
    private bool isFirstSwithOn { get; set; } = true;

    private Player _colorPlayer;
    private Player _noColorPlayer;

    private void Awake()
    {
        _colorPlayer = GameObject.FindWithTag("ColorPlayer").GetComponent<Player>();
        _noColorPlayer = GameObject.FindWithTag("NoColorPlayer").GetComponent<Player>();

        if (Element == null)
            return;
        if (Elements == null)
            return;
    }

    public void EndAnimCall()
    {

        if (isFirstSwithOn)
        {
            Debug.Log("ù ����ġ");
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
            isFirstSwithOn = false;
        }

        if (isON && !isFirstSwithOn)
        {
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
        if(!isON && !isFirstSwithOn)
        {
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
