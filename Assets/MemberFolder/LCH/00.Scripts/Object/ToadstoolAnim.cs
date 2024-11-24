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
    private bool _isFristOn = true;

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


        if (_isFristOn)
        {
            isON = true;
            _isFristOn = false;
        }
        else
        {
            isON = false;
            _isFristOn = true;
        }
        if (isON)
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
            isON = false;

        }
        else
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
            isON = true;

        }
    }
}
