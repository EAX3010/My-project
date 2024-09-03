using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput 
{
    private Player_Input_Actions playerInputActions;
    public event EventHandler<EventArgs> OnInteractAction;
    public GameInput()
    {
        playerInputActions = new Player_Input_Actions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetPlayerMovementNormalized()
    {
        Vector3 inputVector = playerInputActions.Player.Move.ReadValue<Vector3>(); 
        return inputVector;
    }
}
