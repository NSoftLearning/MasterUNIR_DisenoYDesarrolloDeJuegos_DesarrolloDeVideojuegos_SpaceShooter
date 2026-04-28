using System;
using UnityEngine;
using UnityEngine.InputSystem;

class Hardpoint : MonoBehaviour
{
    [SerializeField] WeaponDeployer _weaponDeployer;
    [SerializeField] InputActionReference _trigger;
    [SerializeField] WeaponsLIbrarySO _weaponsLibrary;

    
    public void SetWeapon (int weaponIndexInLibrary)
    {
        _weaponDeployer = Instantiate(_weaponsLibrary.availableWeapons[weaponIndexInLibrary].weaponDeployerPrefab, transform.position, transform.rotation, transform);
    }

    public void OnEnable()
    {
        _trigger.action.Enable();

        _trigger.action.started += StartRequestHardpointUse;
        _trigger.action.canceled += CancelRequestHardpointUse;
    }

    private void StartRequestHardpointUse(InputAction.CallbackContext context)
    {
        if (_weaponDeployer == null)
            return;
        _weaponDeployer.StartDeployingWeapons();
    }

    private void CancelRequestHardpointUse(InputAction.CallbackContext context)
    {

        if (_weaponDeployer == null)
            return;
        _weaponDeployer.StopDeployingWeapons();
    }


}