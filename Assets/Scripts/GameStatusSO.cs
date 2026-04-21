using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStatus", menuName = "ScriptableObjects/GameStatus", order = 1)]
public class GameStatusSO : ScriptableObject
{
    [SerializeField] int _score;
    [SerializeField] int _cash;

    public Action<int> scoreChanged;


    public  void HandleEnemyDead (EnemyDeadData enemyDeadData)
    {
        _score += enemyDeadData.scoreProvided;
        _cash += enemyDeadData.currencyProvided;         
    }


}
