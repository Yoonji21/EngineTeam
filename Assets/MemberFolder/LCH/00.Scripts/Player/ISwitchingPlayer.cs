using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchingPlayer : MonoBehaviour,IEntityComponent
{
    private CinemachineVirtualCamera vCam;
    [SerializeField] private GameObject _switchingUI;
    [SerializeField] private GameObject _player;

    private Entity _entity;

    public void SwitchingPlayerUI()
    {
        StartCoroutine(UIclose(_switchingUI, _player, 0.5f));
    }

    private IEnumerator UIclose(GameObject UI, GameObject player, float timer)
    {
        UI.SetActive(true);
        vCam.Follow = null;
        yield return new WaitForSeconds(timer);
        UI.SetActive(false);
        gameObject.SetActive(false);
        player.SetActive(true);
        vCam.Follow = player.transform;
    }

    public void Initialize(Entity entity)
    {
        _entity = entity;
        vCam = FindObjectOfType<CinemachineVirtualCamera>();
    }
}
