using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using static InputReder;

[CreateAssetMenu(menuName = "SO/InputSo")]
public class InputSystem : ScriptableObject, IPlayerActions
{
    public bool isChromatlEablbe = false;
    public bool isAchromatlcEnable = true;
    public Vector2 InputDriection { get; private set; }
    public Action OnJumpEvent;
    public Action OnswithingPlayerColorEvent;
    public Action OnswithingPlayerNoColorEvent;
    public Action OnHoldObjEvent;
    public Action OnInteractionEvent;

    public InputReder _playerInputAction;

    private void OnEnable()
    {
        if (_playerInputAction == null)
        {
            _playerInputAction = new InputReder();
            _playerInputAction.Player.SetCallbacks(this);  //�÷��̾� ��ǲ�� �߻��ϸ� �� �ν��Ͻ��� ����
        }
        _playerInputAction.Player.Enable(); //Ȱ��ȭ
    }

    private void OnDisable()
    {
        
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
        InputDriection = context.ReadValue<Vector2>();
    }

    public void OnSwitchingPlayer(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isAchromatlcEnable)
            {
                OnswithingPlayerColorEvent?.Invoke();
            }
            else if (isChromatlEablbe)
            {
                OnswithingPlayerNoColorEvent?.Invoke();
            }
        }
    }
}
