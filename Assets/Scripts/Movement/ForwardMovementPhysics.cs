using UnityEngine;

public class ForwardMovementPhysics : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidBody;
    [SerializeField] float _velocity;

    private void Start()
    {
        _rigidBody.linearVelocity = transform.right * _velocity; 
    }
}
