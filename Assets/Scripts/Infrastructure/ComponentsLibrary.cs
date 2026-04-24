using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsLibrary : MonoBehaviour
{
    [SerializeField] PlayerLife _playerLife;
    [SerializeField] MainUiController _mainUiController;
    [SerializeField] GameStatusSO _gameStatus;
    [SerializeField] LevelControl _levelControl;

    public Transform PlayerTransform => _playerLife.gameObject.transform;
    public GameStatusSO GameStatus => _gameStatus;
    public LevelControl LevelControl => _levelControl;


    public void Awake()
    {
        ComponentLocatorService.BuildComponentsLibrary(this);
    }



    public void InitializeWiredObjects ()
    {
        _gameStatus.RequestForFreshData();
    }


    private void WireUpUI()
    {
        _gameStatus.scoreChanged += _mainUiController.RefreshCurrency;
        _gameStatus.cashChanged += _mainUiController.RefreshCash;
    }


    private void UnwireUI()
    {
        _gameStatus.scoreChanged -= _mainUiController.RefreshCurrency;
        _gameStatus.cashChanged -= _mainUiController.RefreshCash;
    }

    private void WireUpPlayer()
    {
        _playerLife.PlayerDiedAction += _mainUiController.SetPlayerAsKilled;
        _playerLife.PlayerDamagedAction += _mainUiController.UpdateLifeBar;
    }

    void UnwirePlayer ()
    {
        _playerLife.PlayerDiedAction -= _mainUiController.SetPlayerAsKilled;
        _playerLife.PlayerDamagedAction -= _mainUiController.UpdateLifeBar;
    }




    private void OnEnable()
    {
        WireUpPlayer();
        WireUpUI();

        InitializeWiredObjects();

    }

    private void OnDisable()
    {
        UnwirePlayer();
        UnwireUI();
    }
}
