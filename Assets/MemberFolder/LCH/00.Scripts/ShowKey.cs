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
            Debug.Log("나 등장");
            _fkey.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("나 퇴장");
            _fkey.SetActive(false);
        }
    }
}
