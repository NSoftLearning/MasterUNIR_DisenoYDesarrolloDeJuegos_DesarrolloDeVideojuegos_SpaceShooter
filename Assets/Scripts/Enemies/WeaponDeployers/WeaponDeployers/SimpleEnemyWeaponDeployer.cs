using System;
using UnityEngine;

public class SimpleEnemyWeaponDeployer : MonoBehaviour
{
    [SerializeField] GameObject _weaponToDeploy;
    [SerializeField] Transform _deploymentTransform;

    IWeaponDeployerControl _weaponDeployerControl;

    
    private void Awake()
    {
        _weaponDeployerControl = GetComponent<IWeaponDeployerControl> ();
    }

    private void DeployWeapon()
    {
        if (_deploymentTransform == null)   
            Instantiate(_weaponToDeploy, transform.position, transform.rotation);
        else
            Instantiate(_weaponToDeploy, _deploymentTransform.position, _deploymentTransform.rotation);
    }

    private void OnEnable()
    {
        _weaponDeployerControl.DeployWeapon += DeployWeapon;
    }

    private void OnDisable()
    {
        _weaponDeployerControl.DeployWeapon -= DeployWeapon;
    }


}
