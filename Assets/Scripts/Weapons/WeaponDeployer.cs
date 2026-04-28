using System;
using UnityEngine;


public class WeaponDeployer : MonoBehaviour
{
    [SerializeField] GameObject _weapon;
    [SerializeField] float _burstDelay;
    [SerializeField] float _firstDeploymentDelay;
    [SerializeField] bool _unlimitedAmmo;
    [SerializeField] int _remainingAmmo;
    bool _deployingWeapons;


    int _maxAmmo;
    public Action <float> WeaponDeployed;
    float _nextFireTime;
    bool _oneOrMoreWeaponsDeployedInCycle;

    private void Start()
    {
        _deployingWeapons = false;
        _nextFireTime = Time.time + _burstDelay + _firstDeploymentDelay;
    }

    public void Setup (int initialAmmo, bool isAmmoUnlimited)
    {
        _remainingAmmo = initialAmmo;
        _maxAmmo = initialAmmo;
        _unlimitedAmmo = isAmmoUnlimited; 
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
        if (_remainingAmmo == 0 && !_unlimitedAmmo)
            return;

        GameObject.Instantiate(_weapon, transform.position, transform.rotation);

        if (!_unlimitedAmmo)
        {
            _remainingAmmo--;
        }
        WeaponDeployed?.Invoke((float)_remainingAmmo / (float)_maxAmmo);

    }
}
