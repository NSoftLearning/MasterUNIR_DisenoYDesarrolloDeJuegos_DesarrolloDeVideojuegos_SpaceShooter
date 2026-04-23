using UnityEngine;

public class MoveAndStopPhysics : MonoBehaviour
{
    [SerializeField] float _movementDistance;
    [SerializeField] float _speed;
    [SerializeField] Vector3 _movementDirection;
    [SerializeField] Rigidbody2D _rigidbody;

    Vector3 _spawnPoint;

    private void Start()
    {
        _spawnPoint = transform.position;
        _rigidbody.linearVelocity = _movementDirection * _speed;
    }


    private void Update()
    {
        if (Vector3.Distance(transform.position, _spawnPoint) > _movementDistance)
        {
            _rigidbody.linearVelocity = Vector3.zero;
            return;
        }


    }
}
