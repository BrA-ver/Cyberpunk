using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputReader : MonoBehaviour, PlayerControls.IPlayerActions
{
    PlayerControls controls;

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }

    public event Action jumpPressed;
    public event Action interactPressed;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.AddCallbacks(this);

        controls.Enable();

        //GameManager.gameOver += GameOver;
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void GameOver()
    {
        controls.Disable();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    public void OnAttack(InputAction.CallbackContext context)
    {
        
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Interact Button");
            interactPressed?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) jumpPressed?.Invoke();

        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        LookInput = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        
    }
}
