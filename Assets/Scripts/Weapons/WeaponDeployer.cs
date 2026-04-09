using System;
using UnityEngine;


public class WeaponDeployer : MonoBehaviour
{
    [SerializeField] DamageOnContactWeapon _weapon;
    [SerializeField] float _burstDelay;
    [SerializeField] float _firstDeploymentDelay;

    bool _deployingWeapons;


    float _nextFireTime;

    private void Start()
    {
        _deployingWeapons = false;
        
    }


    private void Update()
    {
        if (!_deployingWeapons)
            return;

        if (Time.time < _nextFireTime)
            return;

        DeployWeapon();
        _nextFireTime = Time.time + _burstDelay;

    }

    public void StartDeployingWeapons()
    {
        _deployingWeapons = true;
        _nextFireTime = Time.time + _firstDeploymentDelay;
    }

    public void StopDeployingWeapons()
    {
        _deployingWeapons = false;
    }

    void DeployWeapon()
    {
        GameObject.Instantiate(_weapon, transform.position, transform.rotation);
    }



}
