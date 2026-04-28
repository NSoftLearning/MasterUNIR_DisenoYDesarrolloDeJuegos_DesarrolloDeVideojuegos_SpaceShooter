using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStatus", menuName = "ScriptableObjects/GameStatus", order = 1)]
public class GameStatusSO : ScriptableObject
{
    [SerializeField] int _score;
    [SerializeField] public int cash;
    [SerializeField] int _nextLevel;
    [SerializeField] public  bool topSlotWeaponSet;
    [SerializeField] public int topSlotWeaponIndex;
    [SerializeField] public bool bottomSlotWeaponSet;
    [SerializeField] public int bottomSlotWeaponIndex;


    public int _currentLevel;


    public Action<int> scoreChanged;
    public Action<int> cashChanged;

    public  void HandleEnemyDead (DamageableDestroyedData enemyDeadData)
    {
        _score += enemyDeadData.scoreModifier;
        cash += enemyDeadData.currencyModifier;

        RequestForFreshData();

    }

    public void RequestForFreshData ()
    {
        scoreChanged.Invoke(_score);
        cashChanged.Invoke(cash);
    }


    [ContextMenu(nameof(ResetGameStatus))]
    public void ResetGameStatus ()
    {
        _score = 0;
        cash = 0;
        _currentLevel = 0;
        _nextLevel = 0;
    }


}
