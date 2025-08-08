using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    // These variables will be used to gather information from PlayerInputs
    public bool isLeftMouseClicked { get; private set; }
    public bool isRightMouseClicked { get; private set; }
    public bool isPickupPressed { get; private set; }
    public bool isMixPaintPressed { get; private set; }
    public bool isSwapDyePressed { get; private set; }
    public Vector2 MoveDirection { get; private set; }



    // Methods Below sets the bools or variables that the game will gather.
    public void OnLeftClick(InputValue value)
    {
        OnLeftClickToggle(value.isPressed);
    }
    public void OnRightClick(InputValue value)
    {
        OnRightClickToggle(value.isPressed);
    }
    public void OnPlayerMove(InputValue value)
    {
        OnMoveToggle(value.Get<Vector2>());
    }
    public void OnPickup(InputValue value)
    {
        OnPickupToggle(value.isPressed);
    }
    public void OnSwapDye(InputValue value)
    {
        OnSwapDyeToggle(value.isPressed);
    }
    public void OnMixPaint(InputValue value)
    {
        OnMixPaintToggle(value.isPressed);
    }



    public void OnMoveToggle(Vector2 direction)
    {
        MoveDirection = direction;
    }

    public void OnLeftClickToggle(bool _isLeftMouseClicked)
    {
        isLeftMouseClicked = _isLeftMouseClicked;
    }
    public void OnRightClickToggle(bool _isRightMouseClicked)
    {
        isRightMouseClicked = _isRightMouseClicked;
    }
    public void OnPickupToggle(bool _isPickupPressed)
    {
        isPickupPressed = _isPickupPressed;
    }
    public void OnSwapDyeToggle(bool _isSwapDyePressed)
    {
        isSwapDyePressed = _isSwapDyePressed;
    }
    public void OnMixPaintToggle(bool _isMixPaintPressed)
    {
        isMixPaintPressed = _isMixPaintPressed;
    }
}
