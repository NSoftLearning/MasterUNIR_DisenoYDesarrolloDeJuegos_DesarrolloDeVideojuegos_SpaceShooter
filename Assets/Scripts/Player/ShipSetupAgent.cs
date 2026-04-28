using Unity.VisualScripting;
using UnityEngine;

public class ShipSetupAgent : MonoBehaviour
{
    [SerializeField] Hardpoint _topHardpoint;
    [SerializeField] Hardpoint _bottomHardpoint;


    private void Start()
    {
        SetWeaponOnTopHardpoint();
        SetWeaoponOnBottomHardpoint();
    }
    public void SetWeaponOnTopHardpoint ()
    {
        if (ComponentLocatorService.Components.GameStatus.topSlotWeaponSet)
            _topHardpoint.SetWeapon(ComponentLocatorService.Components.GameStatus.topSlotWeaponIndex);
    }

    public void SetWeaoponOnBottomHardpoint ()
    {
        if (ComponentLocatorService.Components.GameStatus.bottomSlotWeaponSet)
            _topHardpoint.SetWeapon(ComponentLocatorService.Components.GameStatus.bottomSlotWeaponIndex);
    }
}
