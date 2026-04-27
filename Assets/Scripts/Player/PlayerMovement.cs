using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionReference _movementInputAction;
    [SerializeField] float _maxSpeed;

    [SerializeField] Rigidbody2D _rigidbody2d;
    Vector2 _movementValue;

    private void ChangeMovementState(InputAction.CallbackContext context)
    {
        _movementValue = _movementInputAction.action.ReadValue<Vector2>() * _maxSpeed;
        _rigidbody2d.linearVelocity = _movementValue;
    }

    public void OnEnable()
    {
        _movementInputAction.action.Enable();
        _movementInputAction.action.started += ChangeMovementState;
        _movementInputAction.action.canceled += ChangeMovementState;
        _movementInputAction.action.performed += ChangeMovementState;
    }

    public void OnDisable()
    {
        _movementInputAction.action.Disable();
        _movementInputAction.action.started -= ChangeMovementState;
        _movementInputAction.action.canceled -= ChangeMovementState;
        _movementInputAction.action.performed -= ChangeMovementState;
    }
}


