using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKey : MonoBehaviour
{
    [SerializeField] private GameObject _fkey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _fkey.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _fkey.SetActive(false);
        }
    }
}
