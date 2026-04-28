using System.IO;
using UnityEngine;
 //[CreateAssetMenu(fileName = "DamageableType", menuName = "ScriptableObjects/Damage/NewDamageableType", order = 1)]

[CreateAssetMenu (fileName = "NewWeaponDeployerStoreItem", menuName = "ScriptableObjects/Store/WeaponDeployerStoreItem", order = 1)]
public class WeaponDeployerStoreItemSO : ScriptableObject
{
     public string weaponName;
     public WeaponDeployer weaponDeployerPrefab;
     public int cost;
     public Sprite icon;
     public string description;
     public int ammo;
    public bool unlimitedAmmo = false;
}
