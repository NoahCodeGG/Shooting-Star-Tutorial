using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Player Input")]
public class PlayerInput : ScriptableObject,InputActions.IGameplayActions
{
    public event UnityAction<Vector2> onMove = delegate { };
    public event UnityAction onStopMove = delegate { };
    
    private InputActions m_InputActions;

    private void OnEnable()
    {
        m_InputActions = new InputActions();
        
        m_InputActions.Gameplay.SetCallbacks(this);
    }

    private void OnDisable()
    {
        DisableAllInput();
    }

    public void EnableGameplayInput()
    {
        m_InputActions.Gameplay.Enable();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void DisableAllInput()
    {
        m_InputActions.Gameplay.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) {
            onMove.Invoke(context.ReadValue<Vector2>());
        }

        if (context.phase == InputActionPhase.Canceled) {
            onStopMove.Invoke();
        }
    }
}
