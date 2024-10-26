using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowKey : MonoBehaviour
{
    public UnityEvent OnOffeDit;
    [SerializeField] private GameObject _fkey;
    private Interaction _interaction;

    private void Awake()
    {
        _interaction = GameObject.FindObjectOfType<Interaction>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _interaction.OnoffPlayerDictctionEvent.AddListener(() => OnOffeDit?.Invoke());
            _fkey.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _interaction.OnoffPlayerDictctionEvent.RemoveAllListeners();
            _fkey.SetActive(false);
        }
    }
}
