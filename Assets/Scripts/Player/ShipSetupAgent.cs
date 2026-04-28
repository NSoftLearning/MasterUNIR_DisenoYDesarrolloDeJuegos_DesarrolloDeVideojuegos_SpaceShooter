using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShipSetupAgent : MonoBehaviour
{
    [SerializeField] Hardpoint _topHardpoint;
    [SerializeField] Hardpoint _bottomHardpoint;
    [SerializeField] public WeaponDeployer topWeaponDeployer;
    [SerializeField] public WeaponDeployer bottomWeaponDeployer;

    public  void Initialize ()
    {

        SetWeaponOnTopHardpoint();
        SetWeaoponOnBottomHardpoint();

    }
    public void SetWeaponOnTopHardpoint ()
    {
        if (ComponentLocatorService.Components.GameStatus.topSlotWeaponSet)
            topWeaponDeployer = _topHardpoint.SetWeapon(ComponentLocatorService.Components.GameStatus.topSlotWeaponIndex);
    }

    public void SetWeaoponOnBottomHardpoint ()
    {
        if (ComponentLocatorService.Components.GameStatus.bottomSlotWeaponSet)
            bottomWeaponDeployer = _bottomHardpoint.SetWeapon(ComponentLocatorService.Components.GameStatus.bottomSlotWeaponIndex);
    }
}

