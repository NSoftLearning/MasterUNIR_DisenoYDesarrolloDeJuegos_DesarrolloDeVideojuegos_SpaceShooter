using System;
using UnityEngine;

public partial class TimedBurstsWeaponDeployerControl : MonoBehaviour, IWeaponDeployerControl
{

    [SerializeField] float _shotDelay;
    [SerializeField] float _burstDelay;    
    [SerializeField] TimedburstStates _currrentState;
    [SerializeField] int _currentShotsPerBurst;
    [SerializeField] int _maxShotsPerBurst;


    public event Action DeployWeapon;
    float _nextBurstTime;
    float _nextFireTime;
    int _shotsFiredThisBurst;
    
    
    public void Start()
    {
        _nextBurstTime = Time.time + _burstDelay;
        _shotsFiredThisBurst = 0;
        
    }


    public void Update()
    {
        switch (_currrentState)
        {
            case TimedburstStates.chargingtBurst:
                UpdateChargingBurstState();
                break;

            case TimedburstStates.firingBurst:
                UpdateFiringBurstState();
                break;
        }
        
    }

    private void UpdateChargingBurstState()
    {
        if (Time.time > _nextBurstTime)
        {
            _currrentState = TimedburstStates.firingBurst;
            _nextFireTime = Time.time + _shotDelay;
        }
    }

    private void UpdateFiringBurstState()
    {
        if (Time.time > _nextFireTime)
        {
            DeployWeapon.Invoke();
            _shotsFiredThisBurst++;
            _nextFireTime = Time.time + _shotDelay;

            if (_shotsFiredThisBurst >= _currentShotsPerBurst)
            {
                _currrentState = TimedburstStates.chargingtBurst;
                _nextBurstTime = Time.time + _burstDelay;
                _shotsFiredThisBurst = 0;
                _currentShotsPerBurst = Mathf.Min(_currentShotsPerBurst + 1, _maxShotsPerBurst);
            }

        }
    }
}
