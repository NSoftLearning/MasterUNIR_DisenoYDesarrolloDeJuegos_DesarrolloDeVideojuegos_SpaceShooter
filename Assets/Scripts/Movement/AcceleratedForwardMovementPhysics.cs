using System;
using UnityEngine;

public class AcceleratedForwardMovementPhysics : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidBody;
    [SerializeField] float _startingVelocity;
    [SerializeField] float _maxVelocity;
    [SerializeField] float _timeToMaxVelocity;
    [SerializeField] float _startAccelerationDelay;


    public event Action maxSpeedReached;
    public event Action accelerationStarted;

    float _launchTime;
    float _startAccelerationTime;
    float _maxVelocityReachTime;
    bool isAcelerating = false;
    private void Start()
    {
        _rigidBody.linearVelocity = transform.right * _startingVelocity;
        _launchTime = Time.time;
        _startAccelerationTime = Time.time + _startAccelerationDelay;
        _maxVelocityReachTime = _startAccelerationTime + _timeToMaxVelocity;
        Debug.Log("initial velocity " + _rigidBody.linearVelocity.magnitude);
    }

    private void Update()
    {

        if (Time.time < _startAccelerationTime)
            return;
        if (_rigidBody.linearVelocity.magnitude >= _maxVelocity)
            return;
        if (!isAcelerating)
            accelerationStarted.Invoke();

        isAcelerating = true;

        float newVelocity = Mathf.Lerp(_startingVelocity, _maxVelocity, (Time.time - _startAccelerationTime) / _timeToMaxVelocity);
        
        _rigidBody.linearVelocity = _rigidBody.linearVelocity.normalized * newVelocity;
        maxSpeedReached.Invoke();    

    }

}
