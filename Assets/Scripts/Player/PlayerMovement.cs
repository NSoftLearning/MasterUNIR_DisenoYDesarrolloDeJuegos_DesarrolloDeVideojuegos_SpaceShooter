using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionReference _movementInputAction;
    [SerializeField] float _maxSpeed;

    [SerializeField] Rigidbody2D _rigidbody2d;

    public void OnEnable()
    {
        _movementInputAction.action.Enable();
    }


    private void Update()
    {
        _rigidbody2d.linearVelocity =_movementInputAction.action.ReadValue<Vector2>() * _maxSpeed;        
    }


    public void OnDisable()
    {
        _movementInputAction.action.Disable();
    }
}


