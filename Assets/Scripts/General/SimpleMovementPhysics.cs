using UnityEngine;

public class SimpleMovementPhysics : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Vector2 _direction;
    [SerializeField] Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody.linearVelocity = _direction.normalized * _speed;
    }

}
