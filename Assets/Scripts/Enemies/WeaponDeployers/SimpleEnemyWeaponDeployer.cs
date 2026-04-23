using System;
using UnityEngine;

public class SimpleEnemyWeaponDeployer : MonoBehaviour
{
    [SerializeField] GameObject _weaponToDeploy;

    IWeaponDeployerControl _weaponDeployerControl;

    
    private void Awake()
    {
        _weaponDeployerControl = GetComponent<IWeaponDeployerControl> ();
    }

    private void DeployWeapon()
    {
        Instantiate(_weaponToDeploy, transform.position, transform.rotation);
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
