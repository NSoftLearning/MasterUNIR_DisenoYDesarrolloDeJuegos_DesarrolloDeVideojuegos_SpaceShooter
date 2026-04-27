using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStatus", menuName = "ScriptableObjects/GameStatus", order = 1)]
public class GameStatusSO : ScriptableObject
{
    [SerializeField] int _score;
    [SerializeField] int _cash;
    [SerializeField] int _nextLevel;

    public int _currentLevel;


    public Action<int> scoreChanged;
    public Action<int> cashChanged;

    public  void HandleEnemyDead (DamageableDestroyedData enemyDeadData)
    {
        _score += enemyDeadData.scoreModifier;
        _cash += enemyDeadData.currencyModifier;

        RequestForFreshData();

    }

    public void RequestForFreshData ()
    {
        scoreChanged.Invoke(_score);
        cashChanged.Invoke(_cash);
    }


    [ContextMenu(nameof(ResetGameStatus))]
    public void ResetGameStatus ()
    {
        _score = 0;
        _cash = 0;
        _currentLevel = 0;
        _nextLevel = 0;
    }


}
