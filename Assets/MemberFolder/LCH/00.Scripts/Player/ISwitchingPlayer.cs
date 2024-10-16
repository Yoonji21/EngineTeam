using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingPlayer : MonoBehaviour
{

    [SerializeField] private GameObject _switchingUI;
    [SerializeField] private GameObject _player;

    public void SwitchingPlayerUI()
    {
        StartCoroutine(UIclose(_switchingUI, _player, 0.5f));
    }

    private IEnumerator UIclose(GameObject UI, GameObject player, float timer)
    {
        UI.SetActive(true);
        yield return new WaitForSeconds(timer);
        UI.SetActive(false);
        gameObject.SetActive(false);
        player.SetActive(true);
    }
}
