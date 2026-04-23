using System;
using UnityEngine;

public class TimeBasedWeaponDeployerControl : MonoBehaviour, IWeaponDeployerControl
{
    //[SerializeField] GameObject _weapon;
    [SerializeField] float _initialDelay;
    [SerializeField] float _burstDelay;


    float nextFireTime;

    public event Action DeployWeapon;

    private void Start()
    {
        nextFireTime = Time.time + _initialDelay;
    }

    private void Update()
    {
        if (Time.time < nextFireTime)
            return;


        
        DeployWeapon.Invoke();
        nextFireTime = Time.time + _burstDelay;
    }

}
