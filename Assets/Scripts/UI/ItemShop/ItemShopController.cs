using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopController : MonoBehaviour
{
    [SerializeField] Transform _topWeaponList;
    [SerializeField] Transform _bottomWeaponList;
    [SerializeField] ShopItemButton _itemButtonPrefab;
    [SerializeField] DescriptionPanel _descriptionPanel;
    [SerializeField] ShopWeaponSlot _topSlot;
    [SerializeField] ShopWeaponSlot _bottomSlot;
    [SerializeField] TMP_Text _availableCash;

    [SerializeField] WeaponsLIbrarySO _weaponsLibrary;
    [SerializeField] GameStatusSO _gameStatus;
    private void Start()
    {
        _gameStatus.topSlotWeaponSet = false;
        _gameStatus.bottomSlotWeaponSet = false;

        _availableCash.text = _gameStatus.cash.ToString();
        for (int i = 0; i < _weaponsLibrary.availableWeapons.Count; i++)
        {
           ShopItemButton newButton =  Instantiate(_itemButtonPrefab, _topWeaponList);
            newButton.Intialize(i, _weaponsLibrary.availableWeapons[i].weaponName, _weaponsLibrary.availableWeapons[i].cost, _descriptionPanel);
            newButton.ShopItemButtonClicked += BuyTopSlotWeapon;

            ShopItemButton newButton2 = Instantiate(_itemButtonPrefab, _bottomWeaponList);
            newButton2.Intialize(i, _weaponsLibrary.availableWeapons[i].weaponName, _weaponsLibrary.availableWeapons[i].cost, _descriptionPanel);
            newButton2.ShopItemButtonClicked += BuyBottomSlotWeapon;
        }
    }

    public void BuyTopSlotWeapon (int index)
    {
        if (_gameStatus.cash < _weaponsLibrary.availableWeapons[index].cost)
            return;
        if (_gameStatus.topSlotWeaponSet)
            return;

        _gameStatus.cash -= _weaponsLibrary.availableWeapons[index].cost;
        _availableCash.text = _gameStatus.cash.ToString();
        _gameStatus.topSlotWeaponSet = true;
        _gameStatus.topSlotWeaponIndex = index;
        _topSlot.SetItem(_weaponsLibrary.availableWeapons[index].icon);
    }

    public void BuyBottomSlotWeapon (int index)
    {
        if (_gameStatus.cash < _weaponsLibrary.availableWeapons[index].cost)
            return;
        if (_gameStatus.bottomSlotWeaponSet)
            return;

        _gameStatus.cash -= _weaponsLibrary.availableWeapons[index].cost;
        _availableCash.text = _gameStatus.cash.ToString();
        _gameStatus.bottomSlotWeaponSet = true;
        _gameStatus.bottomSlotWeaponIndex = index;
        _bottomSlot.SetItem(_weaponsLibrary.availableWeapons[index].icon);
    }

    public void ReleaseTopSlotWeapon ()
    {
        _gameStatus.cash +=  _weaponsLibrary.availableWeapons[_gameStatus.topSlotWeaponIndex].cost;
        _availableCash.text = _gameStatus.cash.ToString();
        _gameStatus.topSlotWeaponSet = false;
    } 

    public void ReleaseBottomSlotWeapon ()
    {
        _gameStatus.cash += _weaponsLibrary.availableWeapons[_gameStatus.bottomSlotWeaponIndex].cost;
        _availableCash.text = _gameStatus.cash.ToString();
        _gameStatus.bottomSlotWeaponSet = false;
    }


}


