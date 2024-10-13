using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using static InputReder;

[CreateAssetMenu(menuName = "SO/InputSo")]
public class InputSystem : ScriptableObject, IPlayerActions
{

    public Action<Vector2> OnMovementEvent;
    public Action OnJumpEvent;
    public Action OnswithingPlayerEvent;
    public Action OnHoldObjEvent;
    public Action OnInteractionEvent;

    private InputReder _playerInputAction;

    private void OnEnable()
    {
        if (_playerInputAction == null)
        {
            _playerInputAction = new InputReder();
            _playerInputAction.Player.SetCallbacks(this);  //�÷��̾� ��ǲ�� �߻��ϸ� �� �ν��Ͻ��� ����
        }
        _playerInputAction.Player.Enable(); //Ȱ��ȭ
    }


    public void OnHold(InputAction.CallbackContext context)
    {
        OnHoldObjEvent?.Invoke();
    }

    public void OnInteractions(InputAction.CallbackContext context)
    {
        OnInteractionEvent?.Invoke();
    }

    public void OnJunmp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnJumpEvent?.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        OnMovementEvent?.Invoke(value);
    }

    public void OnSwitchingPlayer(InputAction.CallbackContext context)
    {
        OnswithingPlayerEvent?.Invoke();
    }
}
