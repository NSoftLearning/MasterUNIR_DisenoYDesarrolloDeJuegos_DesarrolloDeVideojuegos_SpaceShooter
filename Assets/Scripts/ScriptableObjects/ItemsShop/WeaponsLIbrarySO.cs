using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponsLibrary", menuName = "ScriptableObjects/Store/WeaponsLibrary", order = 2)]
public class WeaponsLIbrarySO : ScriptableObject
{
    [SerializeField] public List<WeaponDeployerStoreItemSO> availableWeapons;

}
