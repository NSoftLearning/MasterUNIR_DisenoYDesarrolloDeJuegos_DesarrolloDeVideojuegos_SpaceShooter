using System;
using UnityEngine;


public class WeaponDeployer : MonoBehaviour
{
    [SerializeField] DamageOnContactWeapon _weapon;
    [SerializeField] float _burstDelay;
    [SerializeField] float _firstDeploymentDelay;

    bool _deployingWeapons;


    float _nextFireTime;
    bool _oneOrMoreWeaponsDeployedInCycle;

    private void Start()
    {
        _deployingWeapons = false;
        _nextFireTime = Time.time + _burstDelay + _firstDeploymentDelay;
    }


    private void Update()
    {
        if (!_deployingWeapons)
            return;

        if (Time.time < _nextFireTime)
            return;

        DeployWeapon();
        _oneOrMoreWeaponsDeployedInCycle = true;
        _nextFireTime = Time.time + _burstDelay;

    }

    public void StartDeployingWeapons()
    {        
        _deployingWeapons = true;
        _oneOrMoreWeaponsDeployedInCycle = false;
    }

    public void StopDeployingWeapons()
    {        
        _deployingWeapons = false;
        if (_oneOrMoreWeaponsDeployedInCycle)
            _nextFireTime = Time.time + _burstDelay + _firstDeploymentDelay;
    }

    void DeployWeapon()
    {
        GameObject.Instantiate(_weapon, transform.position, transform.rotation);
    }



}
