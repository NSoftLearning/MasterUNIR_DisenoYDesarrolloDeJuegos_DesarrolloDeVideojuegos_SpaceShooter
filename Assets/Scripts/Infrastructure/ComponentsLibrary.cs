using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ComponentsLibrary : MonoBehaviour
{
    [SerializeField] PlayerLife _playerLife;
    [SerializeField] MainUiController _mainUiController;
    [SerializeField] GameStatusSO _gameStatus;
    [SerializeField] LevelControl _levelControl;
    [SerializeField] GameplayUiController _gameplayUiController;
    [SerializeField] WeaponsLIbrarySO _weaponsLIbrarySO;

    ShipSetupAgent _shipSetupAgent;

    public ShipSetupAgent ShipSetupAgent => _shipSetupAgent;
    public Transform PlayerTransform => _playerLife.gameObject.transform;
    public GameStatusSO GameStatus => _gameStatus;
    public LevelControl LevelControl => _levelControl;
    public GameStatusSO GameStatusSO => _gameStatus;
    public WeaponsLIbrarySO WeaponsLibrary => _weaponsLIbrarySO;

    public void Awake()
    {
        ComponentLocatorService.BuildComponentsLibrary(this);

        _shipSetupAgent = _playerLife.GetComponent<ShipSetupAgent>();
    }

    private void Start()
    {
        _shipSetupAgent.Initialize();
        WireUpWeaponDeployers();
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
        _playerLife.PlayerDiedAction += _gameplayUiController.ShowPlayerDeadUI;
        _levelControl.LevelFinished += _gameplayUiController.ShowLevelClearedUI;
    }

    void UnwirePlayer ()
    {
        _playerLife.PlayerDiedAction -= _mainUiController.SetPlayerAsKilled;
        _playerLife.PlayerDamagedAction -= _mainUiController.UpdateLifeBar;
        _playerLife.PlayerDiedAction -= _gameplayUiController.ShowPlayerDeadUI;
        _levelControl.LevelFinished -= _gameplayUiController.ShowLevelClearedUI;
    }

    public void WireUpWeaponDeployers ()
    {
        if (_shipSetupAgent.topWeaponDeployer != null)        
            _shipSetupAgent.topWeaponDeployer.WeaponDeployed += _gameplayUiController.topWeaponDeployerUI.RefreshOveralyFillAmout;                    
        if (_shipSetupAgent.bottomWeaponDeployer != null)
            _shipSetupAgent.bottomWeaponDeployer.WeaponDeployed += _gameplayUiController.bottomWeaponDeployerUI.RefreshOveralyFillAmout;
    }
    public void UnwireWeaponDeployers ()
    {
        if (_shipSetupAgent.topWeaponDeployer != null)
            _shipSetupAgent.topWeaponDeployer.WeaponDeployed -= _gameplayUiController.topWeaponDeployerUI.RefreshOveralyFillAmout;
        if (_shipSetupAgent.bottomWeaponDeployer != null)
            _shipSetupAgent.bottomWeaponDeployer.WeaponDeployed -= _gameplayUiController.bottomWeaponDeployerUI.RefreshOveralyFillAmout;
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

    private void OnDestroy()
    {
        UnwireWeaponDeployers();
    }
}
