using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    // These variables will be used to gather information from PlayerInputs
    public bool isLeftMouseClicked { get; private set; }
    public Vector2 MoveDirection { get; private set; }



    // Methods Below sets the bools or variables that the game will gather.
    public void OnLeftClick(InputValue value)
    {
        OnLeftClickToggle(value.isPressed);
    }
    public void OnPlayerMove(InputValue value)
    {
        OnMoveToggle(value.Get<Vector2>());
    }


    public void OnMoveToggle(Vector2 direction)
    {
        MoveDirection = direction;
    }
    
    public void OnLeftClickToggle(bool _isLeftMouseClicked)
    {
        isLeftMouseClicked = _isLeftMouseClicked;
    }
}
