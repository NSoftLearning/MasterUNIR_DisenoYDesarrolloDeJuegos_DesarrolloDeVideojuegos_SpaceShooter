using System;
using UnityEngine;
using UnityEngine.InputSystem;

class Hardpoint : MonoBehaviour
{
    [SerializeField] WeaponDeployer _weaponDeployer;
    [SerializeField] InputActionReference _trigger;


    public void OnEnable()
    {
        _trigger.action.Enable();

        _trigger.action.started += StartRequestHardpointUse;
        _trigger.action.canceled += CancelRequestHardpointUse;
    }

    private void StartRequestHardpointUse(InputAction.CallbackContext context)
    {
        _weaponDeployer.StartDeployingWeapons();
    }

    private void CancelRequestHardpointUse(InputAction.CallbackContext context)
    {
        _weaponDeployer.StopDeployingWeapons();
    }


}