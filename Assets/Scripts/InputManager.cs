using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControl playerControl;
    public event EventHandler OnInteractJump;

    private void Awake()
    {
        playerControl = new PlayerControl();
    }

    private void OnEnable()
    {
        playerControl.Enable();
        playerControl.Player.Jump.started += Jump;
    }

    private void OnDisable()
    {
        playerControl.Disable();
        playerControl.Player.Jump.started -= Jump;
    }

    private void Jump(InputAction.CallbackContext contex)
    {
        OnInteractJump?.Invoke(this, EventArgs.Empty);
    }
}
